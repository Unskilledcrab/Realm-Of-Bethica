var date = new Date();
var dayOfWeek = date.getDay();
var hour = date.getHours();
var minute = date.getMinutes();
var itemCount = 0;
var customItemCount = 0;
var nextPageToken = '';
var currentPosition;
var map;
var searchRadius = '1000';
var searchCount = 0;

$('#findPlaces').click(function () {
    if (currentPosition) {
        if (!nextPageToken) {
            $("#choices").empty();
            itemCount = 0;
            itemCount = customItemCount;
        }
        getNearbyPlaces(currentPosition);
        return
    }
    if (navigator.geolocation)
        navigator.geolocation.getCurrentPosition(function (position) {
            currentPosition = position;
            if (!nextPageToken) {
                $("#choices").empty();
                itemCount = 0;
                itemCount = customItemCount;
            }
            getNearbyPlaces(position);
        });
    else
        console.log('geolocation is not supported');
});

function addCustomItem() {
    customItem = $('#customItem').val();
    html = `<div style="margin-top: 15px;display:none;" class="col-12" id="place` + itemCount + `">
  <div class="col">
  <span>    
    <button id="placeBtn` + itemCount + `" class="btn btn-primary disabled" type="button" >
       ` + customItem + ` <span class="badge badge-light">` + 5 + ` <i class="fas fa-star"></i></span>
     </button>
     <button class="btn btn-danger" onclick="removeCustomItem('place` + itemCount + `')"><i class="fas fa-trash-alt"></i></button>
   </span>
   </div>
   </div>`
    itemCount++;
    customItemCount++;
    addToCustomChoices(html, itemCount - 1);
}

function selectRandomItem() {
    if (itemCount == 0) return;
    selectedIndex = Math.floor(Math.random() * itemCount);
    selectedItem = $("#placeBtn" + selectedIndex);
    if (selectedItem.length > 0) {
        $('html, body').animate({
            scrollTop: $("#place" + selectedIndex).offset().top
        }, 1500);
        selectedItem.addClass("btn-success");
        selectedItem.removeClass("btn-primary");
    }
    else {
        selectRandomItem();
    }
}

function removePlace(id) {
    $("#" + id).remove();
}

function removeCustomItem(id) {
    $("#" + id).remove();
    customItemCount--;
}

function getNearbyPlaces(position) {

    var currentPlace = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);

    var request = {
        location: currentPlace,
        radius: searchRadius,
        type: ['restaurant'],
        openNow: true
    };

    service = new google.maps.places.PlacesService(map);
    service.nearbySearch(request, function (data, status) {
        if (searchCount == 0) {
            if (data.length < 20) {
                searchCount++;
                searchRadius = "2000";
                getNearbyPlaces(currentPosition);
                return;
            }
        }
        else if (searchCount == 1) {
            if (data.length < 20) {
                searchCount++;
                searchRadius = "5000";
                getNearbyPlaces(currentPosition);
                return;
            }
        }
        else if (searchCount == 2) {
            if (data.length < 20) {
                searchCount++;
                searchRadius = "10000";
                getNearbyPlaces(currentPosition);
                return;
            }
        }
        else if (searchCount == 3) {
            if (data.length < 20) {
                searchCount++;
                searchRadius = "15000";
                getNearbyPlaces(currentPosition);
                return;
            }
        }
        else if (searchCount == 4) {
            if (data.length < 20) {
                searchCount++;
                searchRadius = "25000";
                getNearbyPlaces(currentPosition);
                return;
            }
        }
        else if (searchCount == 5) {
            if (data.length < 20) {
                searchCount++;
                searchRadius = "50000";
            }
        }
        console.log(data);
        console.log(status);
        nextPageToken = data.next_page_token;
        if (nextPageToken) {
            $('#findPlaces').text("Add More Places");
        }
        else {
            $('#findPlaces').text("Refresh List");
        }
        data.forEach(listPlaces);
    });
}


function initMap() {
    var uluru = { lat: -25.344, lng: 131.036 };
    map = new google.maps.Map(
        document.getElementById('map'), { zoom: 4, center: uluru });
    var marker = new google.maps.Marker({ position: uluru, map: map });
}

function listPlaces(item, index) {
    console.log("getting details: " + index);
    var delay = 0;
    delay = 300 * index;

    var currentCount = itemCount;
    setTimeout(function () { getPlaceDetails(item.place_id, currentCount) }, delay);
    itemCount++;
}

function getPlaceDetails(placeID, index) {

    var request = {
        placeId: placeID,
        fields: ['name', 'rating', 'opening_hours', 'photos', 'price_level', 'reviews', 'formatted_phone_number', 'formatted_address', 'icon', 'website', 'geometry']
    };

    service = new google.maps.places.PlacesService(map);
    service.getDetails(request, function (data, status) {
        console.log(data);
        console.log(status);
        console.log("getting details from API for: " + index);
        formatPlace(data, index);
    });
}

function formatPlace(item, index) {
    console.log("formatting: " + index);
    var html = '';
    html = formatCollapseBegin(item, index);

    html += formatIcon(item);

    html += formatClosingTime(item);
    html += formatPrice(item);
    html += formatPhoneNumber(item);
    html += formatAddress(item);
    html += formatWebsite(item);

    if (item.photos) {
        html += formatCarouselBegin(index);
        for (i = 0; i < item.photos.length; i++) {
            picUrl = item.photos[i].getUrl({ maxWidth: 300, maxHeight: 300 });
            html += formatAddPictureToCarousel(picUrl, i);
        }
        html += formatCarouselEnd(index);
    }

    html += formatReview(item);

    html += formatCollapseEnd(index);
    addToChoices(html, index);
}

function formatCollapseBegin(item, index) {
    return `<div style="margin-top: 15px;display:none;" class="col-12" id="place` + index + `">
  <div class="col">
  <span>    
    <button id="placeBtn` + index + `" class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapse` + index + `" aria-expanded="false" aria-controls="collapseExample">
       ` + item.name + ` <span class="badge badge-light">` + item.rating + ` <i class="fas fa-star"></i></span>
     </button>
     <button class="btn btn-danger" onclick="removePlace('place` + index + `')"><i class="fas fa-trash-alt"></i></button>
   </span>
   <div class="collapse" id="collapse` + index + `">
     <div class="card card-body">`
}

function formatIcon(item) {
    return `<img src="` + item.icon + `" class="rounded mx-auto d-block" alt="icon">`
}

function formatPrice(item) {
    price = '<span>Price: '
    for (i = 0; i < item.price_level; i++) {
        price += `<i class="fas fa-dollar-sign"></i>`;
    }
    price += `</span>`
    return price
}

function formatClosingTime(item) {

    if (item.opening_hours.periods.length == 1) {
        return `<div class="alert alert-success" role="alert">
    This place is always open 
  </div>`
    }
    currentHour = hour * 60;
    currentTime = currentHour + minute;

    closingTime = parseInt(item.opening_hours.periods[dayOfWeek].close.time);

    if (closingTime == 0) closingTime = 2400;
    closingHours = Math.floor(closingTime / 100);
    closingMinutesExtra = parseInt(closingTime.toString().substr(closingTime.toString().length - 2));
    closingTime = closingMinutesExtra + (60 * closingHours);

    if (closingTime < currentTime) {
        closingTime += 1440;
    }
    minutesTillClose = closingTime - currentTime;
    if (minutesTillClose < 60) {
        return `<div class="alert alert-danger" role="alert">
    Closing in ` + minutesTillClose + ` minutes!!!
  </div>`
    }
    else {
        hoursToClose = Math.floor(minutesTillClose / 60);
        minutesToClose = minutesTillClose - (60 * hoursToClose);
        return `<div class="alert alert-success" role="alert">
    Closing in ` + hoursToClose + ` hours & ` + minutesToClose + ` minutes
  </div>`
    }
}

function formatPhoneNumber(item) {
    return `<span><i class="fas fa-phone"></i> <a href="tel:` + item.formatted_phone_number + `">` + item.formatted_phone_number + `</a></span>`
}

function formatAddress(item) {
    if (item.geometry)
        return `<span><i class="fas fa-map-marked-alt"></i> <a href="https://maps.google.com/?q=` + item.formatted_address + `">` + item.formatted_address + `</a></span>`
    else return ""
}

function formatWebsite(item) {
    if (item.website)
        return `<a href="` + item.website + `">View Website</a>`
    else return ""
}

function formatReview(item) {
    author = item.reviews[0].author_name;
    authorPic = item.reviews[0].profile_photo_url;
    authorRating = item.reviews[0].rating;
    authorTimeDesc = item.reviews[0].relative_time_description;
    authorText = item.reviews[0].text;
    authorStars = ' <span>';

    for (i = 0; i < 5; i++) {
        if (authorRating > i) {
            authorStars += `<i class="fas fa-star"></i>`;
        }
        else {
            authorStars += `<i class="far fa-star"></i>`;
        }
    }

    authorStars += `</span>`;

    return `<div class="card mb-3">
  <div class="row no-gutters">
    <div class="col-md-4">
      <img src="` + authorPic + `" class="rounded mx-auto d-block" alt="author picture">
    </div>
    <div class="col-md-8">
      <div class="card-body">
        <h5 class="card-title">` + author + `</h5>
        <h5 class="card-title">` + authorStars + `</h5>		
        <p class="card-text">` + authorText + `</p>
        <p class="card-text"><small class="text-muted">` + authorTimeDesc + `</small></p>
      </div>
    </div>
  </div>
</div>`
}

function formatCarouselBegin(index) {
    return `<div id="carousel` + index + `" class="carousel slide">
    <div class="carousel-inner">`
}

function formatAddPictureToCarousel(picUrl, picIndex) {
    if (picIndex == 0) active = ' active'
    else active = ''
    return `<div class="carousel-item` + active + `">
    <img src=` + picUrl + `" class="d-block w-100" alt="picture` + picIndex + `">
  </div>`
}

function formatCarouselEnd(index) {
    return `</div>
    <a class="carousel-control-prev" href="#carousel` + index + `" role="button" data-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="carousel-control-next" href="#carousel` + index + `" role="button" data-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>`
}

function formatCollapseEnd(index) {
    return `</div>
      </div>
    </div>      
  </div>
  `
}

function addToChoices(html, index) {
    $("#choices").append(html);
    fadeInPlace(index);
}

function addToCustomChoices(html, index) {
    $("#customChoices").append(html);
    fadeInPlace(index);
}

function fadeInPlace(index) {
    var newPlace = $("#place" + index)
    newPlace.css({ "left": '-100px', "opacity": '0' });
    newPlace.show();
    newPlace.animate({ left: '0px', opacity: '1' }, 2000);
}