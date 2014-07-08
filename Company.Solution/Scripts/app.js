/*   
 * Template Name: Unify - Responsive Bootstrap Template
 * Description: Business, Corporate, Portfolio and Blog Theme.
 * Version: 1.3
 * Author: Html Stream
 * Website: http://htmlstream.com/preview/unify
 */

var App = function () {

    function handleIEFixes() {
        //fix html5 placeholder attribute for ie7 & ie8
        if (!jQuery.support.leadingWhitespace) { // ie7&ie8
            jQuery('input[placeholder], textarea[placeholder]').each(function () {
                var input = jQuery(this);

                jQuery(input).val(input.attr('placeholder'));

                jQuery(input).focus(function () {
                    if (input.val() === input.attr('placeholder')) {
                        input.val('');
                    }
                });

                jQuery(input).blur(function () {
                    if (input.val() === '' || input.val() === input.attr('placeholder')) {
                        input.val(input.attr('placeholder'));
                    }
                });
            });
        }
    }

    function handleBootstrap() {
        jQuery('.carousel').carousel({
            interval: 15000,
            pause: 'hover'
        });
        jQuery('.tooltips').tooltip();
        jQuery('.popovers').popover();
    }

    function handleSearch() {
        jQuery('.search').click(function () {
            if (jQuery('.search-btn').hasClass('icon-search')) {
                jQuery('.search-open').fadeIn(500);
                jQuery('.search-btn').removeClass('icon-search');
                jQuery('.search-btn').addClass('icon-remove');
            } else {
                jQuery('.search-open').fadeOut(500);
                jQuery('.search-btn').addClass('icon-search');
                jQuery('.search-btn').removeClass('icon-remove');
            }
        });
    }

    function handleSwitcher() {
        //Sam High - Added Theme Sticky using jquery.cookie plugin
        var themename = 'default';
        if ($.cookie('themename') === undefined) {
            $.cookie('themename', 'default', { expires: 365, path: '/' });
        } else {
            themename = $.cookie('themename');
        }
        $('#themecss').attr("href", "/content/themes/" + themename + "/bootstrap.min.css");
        //attach click changer
        $('.themename').click(function () {
            var themeName = $(this).text();
            var themeUrl = "/content/themes/" + themeName + "/bootstrap.min.css"
            //alert(themeName + ' ' + themeUrl + ' ' +  $('#themecss').attr("href"));
            $.cookie('themename', themeName, { expires: 365, path: '/' });
            $('#themecss').attr("href", themeUrl);
            //alert(themeName + ' ' + themeUrl + ' ' + $('#themecss').attr("href"));

        });
    }

    function handleToolTip() {
        $("[data-toggle='tooltip']").tooltip({
            'delay': { show: 800, hide: 200 }
        });
    }

    function handleTimeOffset() {
        var timezone_cookie = 'timezoneoffset';

        if (!$.cookie(timezone_cookie)) { // if the timezone cookie not exists create one.
            // check if the browser supports cookie
            var test_cookie = 'test cookie';
            $.cookie(test_cookie, true);

            if ($.cookie(test_cookie)) { // browser supports cookie
                // delete the test cookie.
                $.cookie(test_cookie, null);
                // create a new cookie
                $.cookie(timezone_cookie, new Date().getTimezoneOffset());

                location.reload(); // re-load the page
            }
        } else {
            // if the current timezone and the one stored in cookie are different then
            // store the new timezone in the cookie and refresh the page.
            var storedOffset = parseInt($.cookie(timezone_cookie));
            var currentOffset = new Date().getTimezoneOffset();

            if (storedOffset !== currentOffset) { // user may have changed the timezone
                $.cookie(timezone_cookie, new Date().getTimezoneOffset());

                location.reload();
            }
        }
    }

    return {
        init: function () {
            handleBootstrap();
            handleIEFixes();
            //handleSearch();
            handleSwitcher();
            handleToolTip();
            handleTimeOffset();
        },

        initOlarkUser: function (userName, userEmail, userId) {
            App.userName = userName;
            App.userEmail = userEmail;
            App.userId = userId;
            olark('api.chat.updateVisitorNickname', { snippet: userName + ' - ' + userEmail });
            olark('api.visitor.updateFullName', { fullName: userName });
            olark('api.visitor.updateEmailAddress', { emailAddress: userEmail });
            olark('api.visitor.updateCustomFields', { UserId: userId });
        },

        equalizeHeights: function (selector) {
            var maxHeight = 0;

            $(selector).each(function () {
                if ($(this).height() > maxHeight) {
                    maxHeight = $(this).height();
                }
            });

            $(selector).height(maxHeight);
        }
    };
}();

App.userName = null;
App.userEmail = null;
App.userId = null;