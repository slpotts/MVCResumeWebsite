(function($) {

	// GOOGLE MAP
	$(".map").height(250);
	function initialize($) {
		var mapOptions = {	
			zoom: 8,
			center: new google.maps.LatLng(17.421306, 78.457553),
			disableDefaultUI: true
		};
		var map = new google.maps.Map(document.querySelector(".map"), mapOptions);
	}
	google.maps.event.addDomListener(window, 'load', initialize);
	
})(jQuery);