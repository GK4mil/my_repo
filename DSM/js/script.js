//System powstał na Wydziale Informatyki i Nauk o Żywności PWSIiP w Łomży
$('html').addClass('js');
$(window).on("load", function() {
	$("#loader-wrapper").addClass('fout');
	setTimeout(function(){$("#loader-wrapper").fadeOut();}, 800);
});