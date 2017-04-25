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
		phoneUS: {
			params: true,
			message: "电话不合法",
		},
		required: {
			message: "手机号码不能为空！"
		},

	}),

	MemberPassword: ko.observable().extend({
		required: {
			message: "密码不能为空！"
		},
		minLength: {
			params: 6,
			message: "密码长度不能小于6个字符"
		},
		maxLength: {
			params: 18,
			message: "密码长度不能大于18个字符"
		},
	}),
	password1: ko.observable().extend({
		required: {
			message: "确认密码不能为空！"
		},

	}),
	dxyzm: ko.observable('8888').extend({
		required: {
			message: "短息验证码不能为空！"
		}

	}),
	validate: ko.observable().extend({
		required: {
			message: "验证码不能为空！"
		},

	}),

	submit: function() {
		if(viewModel.errors().length === 0) {
			if(viewModel.MemberPassword() == viewModel.password1()) {
				viewModel.GetMemberInfoCreate();
			} else {
				jQuery("#password1").next().show();
				jQuery("#password1").next().text("两次密码不一致!")
			}
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
	GetMemberInfoCreate: function() {
		YamonAPI.POST('/api/Member/MemberInfo/Register', {
			MobileNo: viewModel.phone,
			MemberPassword: viewModel.MemberPassword,
			validate:viewModel.validate,
			codeid:viewModel.codeid
		}, function(result) {
			if(result.success) {
				alert("注册成功！");
				window.location.href = "Login.html"
			} else {
				alert(result.message);
				viewModel.validatecode();
			}
		});
	},
};

viewModel.errors = ko.validation.group(viewModel);

viewModel.requireLocation = function() {
	viewModel.location.extend({
		required: true
	});
};

var register = function() {
	var self = this;
	self.init = function() {
		self.checkboxs();
		viewModel.validatecode();
	}
	self.checkboxs = function() {
		$('input:checkbox').click(function() {
			if($("input[type='checkbox']").is(':checked') == true) {
				jQuery("#btn_login").removeAttr("disabled");
			} else {
				jQuery("#btn_login").attr("disabled", "disabled")
			}
		});
	}
}

var countdown = 60;

function settime(obj) {
	if(countdown == 0) {
		obj.removeAttribute("disabled");
		obj.value = "免费获取验证码";
		countdown = 60;
		return;
	} else {
		obj.setAttribute("disabled", true);
		obj.value = "重新发送(" + countdown + ")";
		countdown--;
	}
	setTimeout(function() {
		settime(obj)
	}, 1000)
}