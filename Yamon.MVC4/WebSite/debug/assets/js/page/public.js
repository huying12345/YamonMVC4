jQuery(function() {
	if($.cookie('__phone') != null) {
		jQuery("#phonename").text($.cookie('__phone'))
	} else {
		jQuery("#backlogin").hide();
	}
	jQuery("#backl").click(function() {
		$.cookie('__token', null);
		$.cookie('__isMemberLogin', null);
		$.cookie('__phone', null);
		if ($.cookie('__token')==null ) {
			window.location.href=YamonAPI.webUrl+"/login.html"
		} else{
			
		}
	})
	jQuery("#yuyue").attr("href","order.html");
		jQuery("#myyy").attr("href","orderlist.html");
})