var YamonAPI = {};
YamonAPI.apiUrl = 'http://localhost:44498';
YamonAPI.webUrl = '';
YamonAPI.POST = function(url, data, callback) {
	if(data == undefined) {
		data = {};
	}
	if(typeof(data) == 'function') {
		callback = data;
		data = {}
	}
	data.ApiKey = '1003';
	if(typeof($.cookie('__token')) == 'undefined' || $.cookie('__token') == '' || $.cookie('__token') == null) {
		$.getScript(YamonAPI.apiUrl + '/api/SiteManage/Application/GetTokenScript?apikey=' + data.ApiKey, function() {
			$.cookie('__token', __token);
			data.token = __token;
			$.ajax({
				url: YamonAPI.apiUrl + url,
				type: 'POST',
				dataType: 'JSON',
				data: data,
				success: function(result) {
					callback(result);
				}
			});
		});
	} else {
		data.token = $.cookie('__token');
		$.ajax({
			url: YamonAPI.apiUrl + url,
			type: 'POST',
			dataType: 'JSON',
			data: data,
			success: function(result) {
				callback(result);
			}
		});
	}
}