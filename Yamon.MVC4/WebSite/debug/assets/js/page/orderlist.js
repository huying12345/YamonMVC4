var index = function(result) {
	var self = this;
	self.lines = ko.observableArray(result);
	self.init = function() {

		console.log(self.lines())
	}

}

function GetProductBookList() {
	YamonAPI.POST('/api/Product/VProductBook/GetProductBookList', function(result) {

		GetProductBookDetailList(result)
	});
}

function GetProductBookDetailList(productBook) {
	YamonAPI.POST('/api/Product/VProductBookDetail/GetProductBookDetailList', function(result) {
		for(var j = 0; j < productBook.length; j++) {

			productBook[j].products = [];

			for(var i = 0; i < result.length; i++) {

				if(result[i].ProductBookID == productBook[j].ProductBookID) {

					productBook[j].products.push(result[i]);

				}
			}
		}

		productBook.allproducts = result;
		console.log(productBook);
		var indexModel = new index(productBook);
		indexModel.init();
		ko.applyBindings(indexModel);

	});
}
jQuery(function() {
	if($.cookie('__isMemberLogin') != null) {
		jQuery("#vbook").removeClass("active");
		GetProductBookList()
	} else {
	alert("请先登录!")
			window.location.href = "Login.html"
	}
})