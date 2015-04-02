(function($) {

	"use strict";
	
	// PRELOADER
	$(window).load(function() {
		$(".loader").fadeOut(400);
	});
	
	// REMOVE # FROM URL
	$('a[href="#"]').click( function(e) {
		e.preventDefault();
	});
	
	// Equal Height
	$(".item").matchHeight();

	// Backstretch
	$(".main-img").backstretch([
		'/images/main-img1.jpg',
		'/images/main-img2.jpg',
		'/images/main-img3.jpg'
	], {duration: 3000, fade: 750});

	// Request Quote Slide Down
	$("#quote-btn").click( function() {	
		$("#request-quote").slideToggle(function() {		
			if($("#request-quote").is(":visible")){
				$("html, body").animate({
					scrollTop: $(".contact-info-bar").offset().top
				}, 1000);
			}			
		});
	});
	
	//MAGNIFIC POPUP
	$('#works-grid, .recent-works').magnificPopup({
		delegate: 'a', 
		type: 'image',
		gallery: {
			enabled: true
		}
	});	
	
	// Works FILTERS
	var $grid = $('#works-grid');
	$grid.shuffle({
		itemSelector: '.works-grid', // the selector for the items in the grid
		speed: 500 // Transition/animation speed (milliseconds)
	});
	/* reshuffle when user clicks a filter item */
	$('#works-filter li a').click(function (e) {
		// set active class
		$('#works-filter li a').removeClass('active');
		$(this).addClass('active');
		// get group name from clicked item
		var groupName = $(this).attr('data-group');
		// reshuffle grid
		$grid.shuffle('shuffle', groupName );
	});
	
	//AJAX CONTACT FORM
	$(".request-quote-form").submit(function() {
		var rd = this;
		var url = "sendemail.php"; // the script where you handle the form input.
		$.ajax({
		type: "POST",
		url: url,
		data: $(".request-quote-form").serialize(), // serializes the form's elements.
		success: function(data)
		{
		//alert("Mail sent!"); // show response from the php script.
		$(rd).prev().text(data.message).fadeIn().delay(3000).fadeOut();
		}
		});
		return false; // avoid to execute the actual submit of the form.
	}); 
	
	
	
})(jQuery);