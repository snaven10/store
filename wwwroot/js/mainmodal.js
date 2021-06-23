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
    const ubicacion = new Localizacion(() => {
        const myLatLng = { lat: ubicacion.latitude, lng: ubicacion.longitude };
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
        $(".btnmodalmap").on("click", function () {
            marcador.setVisible(false);
            let latitude = ($(this).attr("data-lat") * 1);
            let longitude = ($(this).attr("data-long") * 1);
            let myLatLng = { lat: latitude, lng: longitude };
            mapa.setCenter(myLatLng);
            mapa.setZoom(8);
            marcador.setPosition(myLatLng);
            marcador.setVisible(true);
            $('#Modalmap').modal('show');
        });
    });
});

