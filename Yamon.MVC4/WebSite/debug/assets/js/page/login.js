ko.validation.rules.pattern.message = 'Invalid.';

ko.validation.init({
	registerExtenders: true,
	messagesOnModified: true,
	insertMessages: true,
	parseInputAttributes: true,
	messageTemplate: null
}, true);

var viewModel = {
	codeid: '',
	phone: ko.observable().extend({
		/*		phoneUS: {
					params: true,
					message: "电话不合法",
				},*/
		required: {
			message: "手机号码不能为空！"
		},

	}),

	password: ko.observable().extend({
		required: {
			message: "密码不能为空！"
		},

	}),
	validate: ko.observable().extend({
		required: {
			message: "验证码不能为空！"
		},

	}),
	submit: function() {
		if(viewModel.errors().length === 0) {
			viewModel.getMemberInfoLogin();
		} else {

			viewModel.errors.showAllMessages();
		}
	},
	validatecode: function() {
		YamonAPI.POST('/api/SiteManage/ValidateCode/GetValidateCode', function(result) {
			if(result.success) {
				$(".content-img img").attr("src", 'data:image/jpg;base64,' + result.image);
				viewModel.codeid = result.codeid;
			} else {
				alert(result.message);
			}
		});
	},
	getMemberInfoLogin: function() {

		YamonAPI.POST('/api/Member/MemberInfo/MemberLogin', {
			phone: viewModel.phone,
			password: viewModel.password,
			validate: viewModel.validate,
			codeid: viewModel.codeid
		}, function(result) {

			if(result.success) {
				$.cookie('__token', result.token);
				$.cookie('__isMemberLogin', 1);
				$.cookie('__phone', viewModel.phone());
				window.location.href = "order.html"
			} else {
				alert(result.message);
				viewModel.validatecode();
			}
		});
	}
};

viewModel.errors = ko.validation.group(viewModel);

viewModel.requireLocation = function() {
	viewModel.location.extend({
		required: true
	});
};