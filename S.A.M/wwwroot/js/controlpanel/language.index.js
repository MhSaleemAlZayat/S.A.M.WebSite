"use strict";

var LanguageIndex = function () {


	let languageChangeActivityStatusTitle = 'تغيير حالة اللغة';

	let veryfingChangeDefaultLanget = function (languageId, languageName) {

		let modal = new Modal({
			title: "تغيير اللغة الأساسية",
			content: 'هل تريد تغيير اللغة الأساسية للموقع, لتصبح اللغة ' + languageName,
			status: "info",
			size: "lg",
			buttons: [
				{
					label: "إلغاء الأمر",
					className: "bg-gray-300 hover:bg-gray-400",
				},
				{
					label: "نعم",
					className: "bg-blue-600 text-white hover:bg-blue-700",
					onClick: () => {
						changeDefaultLanguage(languageId, languageName);
					}
				}
			]
		});
		modal.show();
	};
	let changeDefaultLanguage = function (languageId, languageName) {		
		$.ajax({
			type: "GET",
			url: '/sam/api/Language/ChangeDefaultLanguage?id=' + languageId + '',
			dataType: "json",
			success: function (data, callback) {
				applyChangeDefaultLanguage(languageId, languageName, data);
			},
			error: function (xhr, status, error) {
				applyChangeDefaultLanguage(languageId, languageName, xhr.responseJSON);
			}
		});
		
	}
	let applyChangeDefaultLanguage = function (languageId, languageName, result) {
		if (result.success) {
			$('.default-language').each(function (i, e) {
				let anchor = $(e).find('a');
				if (anchor != undefined && anchor.length > 0) {
					if (anchor.attr('id') == 'change-default-language-' + languageId) {
						$(e).html('<span class="px-2 inline-flex text-xs leading-5 font-semibold rounded-full bg-green-100 text-green-800" data-translate="record_default" data-id="' + languageId + '">أساسي</span>');
					}
				}
				else {
					let span = $(e).find('span');
					if (span != undefined) {
						$(e).html('<a id="change-default-language-' + span.attr('data-id') + '" onclick="LanguageIndex.changeDefaultLanguage(' + span.attr('data-id') + ', ' + '\'' + languageName + '\''+ ')" href="javascript:void(0);"><span class="px-2 inline-flex text-xs leading0-5 font-semibold rounded-full bg-gray-100 text-blacl-800" data-translate="record_not_default">غير أساسي</span></a>');
					}
				}

			});

			let modal = new Modal({
				title: "تغيير اللغة الأساسية",
				content: '<div>نجحت عملية تغيير اللغة الأساسية </div><p class="text-green-800 text-xl">' + languageName + '</p>',
				status: "success",
				size: "lg",
				buttons: [
					{
						label: "حسناً",
						className: "bg-green-600 text-white hover:bg-green-700",
					}
				]
			});
			modal.show();
		}
		else {
			let modal = new Modal({
				title: "تغيير اللغة الأساسية",
				content: '<div>فشلت عملية تغيير اللغة بسبب خطأ فني : </div><p class="text-red-800 text-xl">' + result.message + '</p>',
				status: "danger",
				size: "lg",
				buttons: [
					{
						label: "حسناً",
						className: "bg-gray-300 hover:bg-gray-400",
					}
				]
			});
			modal.show();
		}
	};


	let veryfingChangeActivationStatus = function (languageId, languageName) {

		let modal = new Modal({
			title: languageChangeActivityStatusTitle,
			content: 'هل تريد تغيير حالة اللغة {' + languageName + '}المستخدمة في الموقع,  لتصبح غير نشطة',
			status: "warning",
			size: "lg",
			buttons: [
				{
					label: "إلغاء الأمر",
					className: "bg-gray-300 hover:bg-gray-400",
				},
				{
					label: "نعم",
					className: "bg-yellow-600 text-white hover:bg-yellow-700",
					onClick: () => {
						changeLanguageActivationStatus(languageId, languageName);
					}
				}
			]
		});
		modal.show();
	};
	let changeLanguageActivationStatus = function (languageId, languageName) {
		$.ajax({
			type: "GET",
			url: '/sam/api/Language/ChangeLanguageActivationStatus?id=' + languageId + '',
			dataType: "json",
			success: function (data, callback) {
				applyChangeLanguageActivationStatus(languageId, languageName, data);
			},
			error: function (xhr, status, error) {
				applyChangeLanguageActivationStatus(languageId, languageName, xhr.responseJSON);
			}
		});

	}
	let applyChangeLanguageActivationStatus = function (languageId, languageName, result) {
		if (result.success) {
			let anchor = $('.language-activation-status').find('a#change-activation-status-' + languageId);

			if (anchor != undefined && anchor.length > 0) {
				if (result.active) {
					$(anchor).parent().html('<a id="change-activation-status-' + languageId + '" onclick="LanguageIndex.changeActivationStatus(' + languageId + ', ' + '\'' + languageName + '\'' + ')" href="javascript:void(0);"><span class="px-2 inline-flex text-xs leading-5 font-semibold rounded-full bg-green-100 text-green-800" data-translate="record_active">نشط</span></a>');
				}
				else {
					$(anchor).parent().html('<a id="change-activation-status-' + languageId + '" onclick="LanguageIndex.changeActivationStatus(' + languageId + ', ' + '\'' + languageName + '\'' + ')" href="javascript:void(0);"><span class="px-2 inline-flex text-xs leading-5 font-semibold rounded-full bg-gray-100 text-black-800" data-translate="record_inactive">متوقف</span></a>');
				}
			}

			let modal = new Modal({
				title: languageChangeActivityStatusTitle,
				content: '<div>نجحت عملية تغيير حالة اللغة </div><p class="text-green-800 text-xl">' + languageName + '</p>',
				status: "success",
				size: "lg",
				buttons: [
					{
						label: "حسناً",
						className: "bg-green-600 text-white hover:bg-green-700",
					}
				]
			});
			modal.show();
		}
		else {
			let modal = new Modal({
				title: languageChangeActivityStatusTitle,
				content: '<div>فشلت عملية تغيير اللغة بسبب خطأ فني : </div><p class="text-red-800 text-xl">' + result.message + '</p>',
				status: "danger",
				size: "lg",
				buttons: [
					{
						label: "حسناً",
						className: "bg-gray-300 hover:bg-gray-400",
					}
				]
			});
			modal.show();
		}
	};
			


	return {
		init: function () {
			
		},
		changeDefaultLanguage: function (languageId, languageName) {
			veryfingChangeDefaultLanget(languageId, languageName)
		},
		changeActivationStatus: function (languageId, languageName) {
			veryfingChangeActivationStatus(languageId, languageName)
		}

	};

}();
$(document).ready(function () {
	
});
