$(function() {
	$('.about').show();
	$('.title').hide();
	$('.backtup').hide();
	$('.header').show();
	$('.title').on('click', function() {
		$(this).hide();
		$('.about').show();
	})
	$('.about span').on('click', function() {
		$('.about').hide();
		$('.title').show();
	})
})

