class Localizacion {
    constructor(callback) {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition((position) => {
                this.latitude = position.coords.latitude;
                this.longitude = position.coords.longitude;
                callback();
            });
        } else {
            alert("Tu navegador no soporta geolocalizacion!! :(")
        }
    }
}
google.maps.event.addDomListener(window, "load", function () {
    function mostrar(latitud, longitud) {
        document.getElementById("Latitud1").value = latitud;
        document.getElementById("Latitud2").value = latitud;
        document.getElementById("Longitud1").value = longitud;
        document.getElementById("Longitud2").value = longitud;
    }
    const ubicacion = new Localizacion(() => {
        let myLatLng;
        if (document.getElementById("Latitud1").value == "") {
            myLatLng = { lat: ubicacion.latitude, lng: ubicacion.longitude };
            mostrar(ubicacion.latitude, ubicacion.longitude);
        } else {
            let lngt = (document.getElementById("Longitud1").value * 1);
            let latd = (document.getElementById("Latitud1").value * 1);
            myLatLng = { lat: latd, lng: lngt };
        }
        const options = {
            center: myLatLng,
            zoom: 15
        }
        let map = document.getElementById("map");
        const mapa = new google.maps.Map(map, options);
        const marcador = new google.maps.Marker({
            position: myLatLng,
            map: mapa,
            draggable: true
        });
        if (document.getElementById("Latitud1") == "") {
            mostrar(ubicacion.latitude, ubicacion.longitude);
        }
        let autocomplete = document.getElementById("autocomplete");
        const search = new google.maps.places.Autocomplete(autocomplete);
        search.bindTo("bounds", mapa);
        search.addListener("place_changed", function () {
            marcador.setVisible(false);

            let place = search.getPlace();
            if (!place.geometry.viewport) {
                window.alert("Error al mostrar elugar");
                return;
            }
            if (place.geometry.viewport) {
                mapa.fitBounds(place.geometry.viewport);
            } else {
                mapa.setCenter(place.geometry.location);
                mapa.setZoom(18);
            }

            marcador.setPosition(place.geometry.location);
            marcador.setVisible(true);
        });
        google.maps.event.addListener(marcador, 'dragend', function (evt) {
            mostrar(evt.latLng.lat().toFixed(6), evt.latLng.lng().toFixed(6));
        });
        
    });
});
