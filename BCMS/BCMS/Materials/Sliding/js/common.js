var TotalBreadcrumbWidth;
var origBreadcrumbWidth;
var newBreadcrumbWidth;

document.createElement("article");
document.createElement("section");




$(document).ready(function(){
var currPageURL=window.location.href;
var isiPhone = /iphone/i.test(navigator.userAgent.toLowerCase());
var isAndroid = /android/i.test(navigator.userAgent.toLowerCase());
var isBlackBerry = /blackberry/i.test(navigator.userAgent.toLowerCase());
var isWindowsPhone = /windows phone/i.test(navigator.userAgent.toLowerCase());
if (isiPhone || isAndroid || isWindowsPhone)
{
	//alert(window.location.href);
  if(currPageURL.indexOf('/ar/')==-1)
  {
	  //alert('english');
      window.location.href = "http://www.borsacapital.com/";
	  return false;
  } 
}
else if(isBlackBerry || (navigator.userAgent.toLowerCase().indexOf('symbian')!=-1))
{
    window.location.href = "http://www.borsacapital.com/";
	return false;
}



if($('#bannerWrap')[0] != null){
	if($('#bannerWrap li').length > 1){
	$('#bannerWrap').bxSlider({
	  mode: 'fade',
	  auto: true,
	  controls: false,
	  autoControls: false,
	  pager: true,
	  pagerType: 'full',
	  pause: 5000,
	  infiniteLoop:true,
	  pagerSelector:'.bx-pager'
	
	});
}
}


	
	/*expanded_dropdown_country: start*/
	$('.right ul li.country').click(function() {
	  $('.right .expanded_dropdown_country').slideDown('slow');
	  $(this).toggleClass("close");
	});	
	
	$(document).click(function(e) {
		if ($(e.target).closest('.country').length === 0 && $(e.target).closest('.expanded_dropdown_country').length === 0 && $(e.target).closest($(".banner_tab").find("li")).length === 0) {
				$(".expanded_dropdown_country").slideUp();
		}
    });
	
	$(".accordion h3 span").click(function()
	{
		if($(this).parent().next(".accordion_content").css("display")!="block")
		{
			$(this).parent().next(".accordion_content").slideDown().siblings(".accordion_content").slideUp();
	  		$(this).parent().addClass("active").siblings("h3").removeClass("active");
		}
		else
		{
			
			$(this).parent().next(".accordion_content").slideUp();
			$(this).parent().removeClass("active");
		}		
	});
	
/*accordian:end*/

/* Home Page Banner Tab Functionality START */
$(".bankingWrapper").children(".bankingContent").eq(0).show();
$(".bankingWrapper li").eq(0).addClass("selected");
$(".bankingWrapper li").hover(function(){
	var thisIndex = $(this).index();
	$(this).addClass("selected").siblings().removeClass("selected");
	$(".bankingWrapper").children(".bankingContent").eq(thisIndex).show().siblings(".bankingContent").hide();
});
/* Home Page Banner Tab Functionality END */


/* Go to Functionality START */
$(".goBtn").click(function(){
	
	if($(".help_section_content select").find("option:selected").attr("target"))
	{
		$(this).attr("target","_blank");
	}
	var selValue = $(".help_section_content select").find("option:selected").attr("rel");
	if(selValue.indexOf("jsp")!=-1)
	{
		window.open(iframeSrc+selValue);
	}
	else
	{
		$(this).attr("href",selValue);
	}
});
/* Go to Functionality END */


/* Home Map Functionality START */
$(".contryTag").hover(function(){
	$(this).css("z-index","3");
	$(this).prev(".contryWrap").css("z-index","3");
	$(this).prev(".contryWrap").find(".countryName").css("z-index","3");
	$(this).prev(".contryWrap").find(".countryName").stop().animate({"margin-left":"0px"});
},function(){
	$(this).css("z-index","1");
	$(this).prev(".contryWrap").css("z-index","1");
	$(this).prev(".contryWrap").find(".countryName").css("z-index","1");
	$(this).prev(".contryWrap").find(".countryName").stop().animate({"margin-left":"135px"});
	});
/* Home Map Functionality END */

	
	/*Select code*/
    $(".select_bg select").each(function () {
        $(this).children("option").each(function () {
            if ($(this).attr("selected")) {
                $(this).parent().prev().html($(this).html());
            }
        });
    });
    $(".select_bg select").change(function () {
        $(this).prev().html($(this).children("option:selected").html());
    });
	/*Select code*/
	
	/*home_banner & inner_banner online_banking: start*/
	origBreadcrumbWidth=parseInt($(".breadcrumbs").width());
	$('#banner_wrapper .button').click(function() {
	  $('#banner_wrapper .online_banking_showhide_content').slideToggle('slow');
	  $(this).toggleClass("close");
	  if($(".rhs").length)
	  {
		  if( $(".rhs").css("margin-top")=="45px")
		  {
			  $(".rhs").animate({"margin-top":"0px"});
		  }
		  else if($(".rhs").css("margin-top")=="0px")
		  {
			  $(".rhs").animate({"margin-top":"45px"});
		  }
		  
	  }
	  
	  TotalBreadcrumbWidth=$("#content_wrapper").children("div").eq(0).width()-parseInt($(".breadcrumbs").css("padding-left"))+parseInt($(".breadcrumbs").css("padding-left"));
	  newBreadcrumbWidth=parseInt($(".breadcrumbs").width());	  
	  
	  if(newBreadcrumbWidth!=TotalBreadcrumbWidth)
	  {
		  $('.breadcrumbs').animate({"width":TotalBreadcrumbWidth+"px"},1000);
	  }
	  else
	  {
		  $('.breadcrumbs').animate({"width":origBreadcrumbWidth+"px"});
	  }
	});	
	/*home_banner & inner_banner online_banking: end*/
	
	var mainNavIndex = $(".nav").find("li.sel").not(".subLevel_one .sel").index();
	//var subNavIndex = $(".nav").find(".subLevel_one .sel").not(".subLevel_two .sel").index();
	var subNavIndex =$(".nav ul").children(".sel").children(".subLevel_one").children("ul").children(".sel").index();
	var subMenuClass = $(".subMenu").find("div").attr("class");
	var thirdNav = $(".subLevel_two").find(".sel").index();
	
	$(".subLevel_two li").hover(function(){
		
	},function(){
		//alert(thirdNav);
		$(".nav").find(".subLevel_one .sel").find(".subLevel_two li").eq(thirdNav).addClass("sel");
	});
	
	
	/*Nav subLevel_two:start*/
	$('.subLevel_one > ul > li').hover(
		function(){
			if ($(this).find('.subLevel_two').length != 0)
				$(this).find('.subLevel_two').stop(true,true).slideDown('slow');
				$(this).siblings().removeClass("sel");
		}, 
	    function () {
			$(this).find(".subLevel_two").hide();
			//alert($(".nav").find(".subLevel_one").find("li").eq(subNavIndex).attr("class"));
			if(subNavIndex==-1)
			{
				$(this).find(".subLevel_one ul li").removeClass("sel");
			}
			else
			{
				$(".nav ul").children(".sel").children(".subLevel_one").children("ul").children("li").eq(subNavIndex).addClass("sel");
			}
  		}
	);
	
	
	/*footer_top_section_content:start*/
	 
	 	/** setting cookie for Floating Footer starts **/
	  	if(!$.cookie("fl_footer_state"))
	  	{
	  		$.cookie("fl_footer_state","expand",{path:'/'})
	  	}
	  	else if($.cookie("fl_footer_state")=="collapse")
	  	{
	  		$(".footer_top_section_content").css("overflow","hidden");
	  		$(".footer_top_section_content ul").stop().animate({"margin-left":"-953px"});
	  		$.cookie("fl_footer_state","collapse",{path:'/'});
	  		$(".footer_top_section_content .button").toggleClass("close");
	  	}
	  	/** setting cookie for Floating Footer ends **/
		
		
		$(".footer_top_section_content .button").click(function(){
		 	$(this).parent().css("overflow","hidden");
			$(".footer_top_section_content ul").stop().animate({"margin-left":"-953px"});
			$.cookie("fl_footer_state","collapse",{path:'/'});
			$(this).toggleClass("close");
			
			if($(".footer_top_section_content ul").css("margin-left")=="-953px")
			{
				$(".footer_top_section_content ul").stop().animate({"margin-left":"0px"});
				$.cookie("fl_footer_state","expand",{path:'/'});
				setTimeout(function(){
					$(".footer_top_section_content").css("overflow","");
				},500);
			}					   
		  });
	/*footer_top_section_content:end*/
	
	/*infoTab:start*/
	$('.tabCotent .infoTab ul li').click(function(){
		$(this).addClass('sel').siblings().removeClass('sel');
		$('.tabCotent .infoTabContent').eq( $(this).index() ).show().siblings('.tabCotent .infoTabContent').hide();
	}).eq(0).click();
	/*infoTab:end*/
	
	/** Show details in the third level NAV **/
	$(".nav_inner_banner_right").each(function(){
		$(this).children("ul").not(":first").hide();
	});
	$(".subLevel_two").find(".nav_inner_banner_left").find("li").mouseover(function(){
		if($(".nav_inner_banner_right").children("ul").length>1)
		{
			var thisElemIndex=$(this).index();
			$(".nav_inner_banner_right").children("ul").eq(thisElemIndex).show().siblings("ul").hide();
		}
	});
	
	
	
	/** Show details in the third level NAV **/
	
	/*sitemap: start*/
	$('#footer_wrapper .footer_bottom_section .sitemap .sitemap_content a').click(function() {
	  $('#footer_wrapper .footer_middle_section').slideToggle('slow');
	  $(this).toggleClass("close");
	});	
	
	$(".sitemap_content a").click(function(){
		//alert(0)
		var offset = $(this).offset().top;
		$('body,html').animate({ scrollTop: offset }, 900);
		});
	/*sitemap: end*/
	


/* Banner Slide Functionality START */
	
	var clientWidth = $(window).width();
	counter = 0;
	var bannerLength = $(".bannerWrap").find("li").length*clientWidth;
	var currLeft = parseInt($(".bannerWrap").find("ul").css("left"))*(-1);
	
		 /* * * * * * *  Specify Your Code Here * * * * * * * * * */
	
    var $slider = $(".bannerWrap ul"); 			// Slider - Div That will be Animated
    var $sliderImages = $(".bannerWrap ul li"); 	// Slider Images/Divs - Slides of the SlideShow			
    var $pagination = $("ul.prevNext li"); 	// Pagination - Click Buttons
	var $interval = 3000;					// Auto Animation Interval
	var $animSpeed = 500;					// Animation Speed 
	var $autoLoop;							// Autolooping Variable, change only if already have same name variable somewhere.
	
	
	/* * * * * * *  Auto Code From Here * * * * * * * * * * */
	
	//$(".bannerWrap").find("ul").css("width",bannerLength);
	
	if(clientWidth>1280)
	{
		screenResolution=1280;
	}
	else
	{
		screenResolution=$("#wrapper").width();
	}
	
	$(".subMenu, #banner_wrapper, #nav_wrapper, #header_wrapper, #content_wrapper, #footer_wrapper").css("width",$("#wrapper").width());
	$(".subMenu").children().css("width",$("#wrapper").width());
	
	$(".banner_container").css("width",screenResolution);
	$(".bannerWrap").find("li").css("width",screenResolution);
	var marLeft = (clientWidth - screenResolution)/2;
	var bannerLength = $(".bannerWrap").find("li").length*screenResolution;
	//$(".banner_container").css("margin-left",marLeft);
	$(".banner_container").css("margin","auto");
	
	var timer=0;

/*Home Page Banner Functionality START */
	
    var $sliderWidth = $sliderImages.width() * $sliderImages.length;
    //var $sliderAnim = $sliderImages.width() * -1;
    var $lastClick = 0;
	
	//$sliderImages.eq(0).nextAll().hide();
   // $slider.css("width", $sliderWidth);
	//alert($sliderImages.length);
	
	
	//$(window).focus(function(){$(".banner_tab").find("li").eq(0).trigger("click")});
/* Banner Slide Functionality END */



/*Custom checkboxes and radio button:start*/
var d = document;
    var safari = (navigator.userAgent.toLowerCase().indexOf('safari') != -1) ? true : false;
    var gebtn = function(parEl,child) { return parEl.getElementsByTagName(child); };
    onload = function() {
        
        var body = gebtn(d,'body')[0];
        body.className = body.className && body.className != '' ? body.className + ' has-js' : 'has-js';
        
        if (!d.getElementById || !d.createTextNode) return;
        var ls = gebtn(d,'label');
        for (var i = 0; i < ls.length; i++) {
            var l = ls[i];
            if (l.className.indexOf('label_') == -1) continue;
            var inp = gebtn(l,'input')[0];
            if (l.className == 'label_check') {
                l.className = (safari && inp.checked == true || inp.checked) ? 'label_check c_on' : 'label_check c_off';
                l.onclick = check_it;
            };
            if (l.className == 'label_radio') {
                l.className = (safari && inp.checked == true || inp.checked) ? 'label_radio r_on' : 'label_radio r_off';
                l.onclick = turn_radio;
            };
        };
    };
    var check_it = function() {
		var inp = gebtn(this,'input')[0];
		//this.childNodes[0].checked=true;
		//alert(this.className);
		
		
		if(this.getElementsByTagName('input')[0].checked==true)
		{
			//alert("true");
			this.className = 'label_check c_on';
		}
		else
		{
			//alert("false");
			this.className = 'label_check c_off';
		}
		
        /*if (this.className == 'label_check c_off' || (!safari && inp.checked)) {
            this.className = 'label_check c_on';
			this.getElementsByTagName('input')[0].checked=true;
            if (safari) inp.click();
		} else if (this.className == 'label_check c_on') {
            this.className = 'label_check c_off';
			this.getElementsByTagName('input')[0].checked=false;
            if (safari) inp.click();
        };*/
    };
    var turn_radio = function() {
        var inp = gebtn(this,'input')[0];
        if (this.className == 'label_radio r_off' || inp.checked) {
            var ls = gebtn(this.parentNode,'label');
            for (var i = 0; i < ls.length; i++) {
                var l = ls[i];
                if (l.className.indexOf('label_radio') == -1)  continue;
                l.className = 'label_radio r_off';
            };
            this.className = 'label_radio r_on';
            if (safari) inp.click();
        } else {
            this.className = 'label_radio r_off';
            if (safari) inp.click();
        };
    };
/*Custom checkboxes and radio button:start*/


/* Footer Navigation START */
$(".footer_top_section_content").find("li").hover(function(){
	$(this).addClass("sel").siblings().removeClass("sel");
	$(this).find('.first_level').stop(true,true).slideDown();
},function(){
	$(this).removeClass("sel");
	$(this).find('.first_level').stop(true,true).slideUp();
});
/* Footer Navigation END */

	/** Increase / Decrease Font-Size Starts **/
	$(".increaseFontSize").children("li").click(function(){
		$(this).addClass("sel").siblings("li").removeClass("sel");
		if($(this).hasClass("small"))
		{
			$(".content_section").children("article").css("font-size","0.90em");
			$(".content_home").children("section").css("font-size","0.90em");
		}
		else if($(this).hasClass("medium"))
		{
			$(".content_section").children("article").css("font-size","1em");
			$(".content_home").children("section").css("font-size","1em");
		}
		else if($(this).hasClass("greater"))
		{
			$(".content_section").children("article").css("font-size","1.05em");
			$(".content_home").children("section").css("font-size","1.05em");
		}
	});
	/** Increase / Decrease Font-Size Ends **/
	/** Online Banking starts **/
	$(".online_banking_content").find(".go").children("input").click(function(){
		if($(".online_banking_content").find("select").val()=="Personal Login")
		{
			window.open('https://www.samba.com/Arabic/common/HTML/SOLogin_01_01_ar_New.html');
		}
		else if($(".online_banking_content").find("select").val()=="Corporate Login")
		{
			window.open('https://www.samba.com/Arabic/common/HTML/SALogin_01_01_ar_New.html');
		}
	});
	/** Online Banking ends **/
	
	/** Recently Veiwed starts **/
	var currPageTitle;
	var currPageURL;
	if(!$.cookie("recentlyViewedAR"))
	{
		currPageTitle=$("title").html();
		currPageURL=window.location.href;
		$.cookie("recentlyViewedAR",currPageTitle+"~",{path:'/'});
		$.cookie("recentlyViewedARURL",currPageURL+"~",{path:'/'});
		$("#footer_wrapper").find(".recent").children(".first_level").children("ul").append("<li><a href="+currPageURL+">"+currPageTitle+"</a></li>");
	}
	else
	{
		currPageTitle=$("title").html();
		currPageURL=window.location.href;
		if($.cookie("recentlyViewedAR").indexOf('~')!="-1")
		{
			var flagSplit=true;
			var cookieSplit=$.cookie("recentlyViewedAR").split('~');
			var cookieURLSplit=$.cookie("recentlyViewedARURL").split('~');
			
			for(i=0;i<cookieSplit.length;i++)
			{
				if(currPageTitle==cookieSplit[i])
				{
					flagSplit=false;					
					break;
				}
				else if(currPageTitle!=cookieSplit[i])
				{
					flagSplit=true;					
				}
			}
			
			if(cookieSplit.length==6)
			{
				var oldC = $.cookie("recentlyViewedAR");
				var newC = oldC.replace(cookieSplit[0]+'~','');
				
				var oldCURL = $.cookie("recentlyViewedARURL");
				var newCURL= oldCURL.replace(cookieURLSplit[0]+'~','');
				
				if(flagSplit==true){
					$.cookie("recentlyViewedAR",newC+currPageTitle+"~",{path:'/'});
					$.cookie("recentlyViewedARURL",newCURL+currPageURL+"~",{path:'/'});
				}
			}
			else
			{
				if(flagSplit==true){
					$.cookie("recentlyViewedAR",$.cookie("recentlyViewedAR")+currPageTitle+"~",{path:'/'});
					$.cookie("recentlyViewedARURL",$.cookie("recentlyViewedARURL")+currPageURL+"~",{path:'/'});
				}
			}
				
			var cookieSplit=$.cookie("recentlyViewedAR").split('~');
			var cookieURLSplit=$.cookie("recentlyViewedARURL").split('~');
			var cont ='';
				for(i=cookieSplit.length-2;i>=0;i--)
				{
					cont += "<li><a href="+cookieURLSplit[i]+">"+cookieSplit[i]+"</a></li>";
				}
				
			$("#footer_wrapper").find(".recent").children(".first_level").children("ul").append(cont);				
		}
	}
	/** Recently Veiwed ends **/
	/** English to Arabic and Vice-versa starts **/
	$(".language").click(function(){
		if(window.location.href.indexOf("ar")!=-1)
		{
			window.location.href=window.location.href.replace(/ar/,'en');
		}
		else
		{
			window.location.href="/en/personal-banking.html";
		}
		
		$.cookie("language","",{expires : 365, path:'/'});
		$.cookie("language","english",{expires : 365, path:'/'});
		return false;		
	});
	
	/** English to Arabic and Vice-versa ends **/
	/** Print functionality starts **/
	$(".print").click(function(){
		window.print();
	});
	/** Print functionality ends **/
	
	
		$(".map_section .button").click(function(){
		if(!$(this).hasClass("close"))
		{
			$(".map_address").animate({"margin-right":"-198px"});
			$(".show_map").animate({"width":"+=198px"});
			$(this).addClass("close").animate({"left":"690px"});
		}
		else
		{
			$(".map_address").animate({"margin-right":"0"});
			$(".show_map").animate({"width":"-=198px"});
			$(this).removeClass("close").animate({"left":"540px"});
		}
		});
		
		
	/*FAQs:start*/
	$('.heading_section .select_bg select').change(function(){
		$('.faqs_details').eq($(this).children("option:selected").index()).show().siblings('.faqs_details').hide();
		//alert($(this).children("option:selected").index());
		//$('.faqs_details').eq($(this).children("option:selected").index()).find(".accordion h3").eq(0).children("span").click();
	}).eq(0).change();
	/*FAQs:end*/
	
	/** Show details in the third level NAV **/
	$(".nav_inner_banner_right").each(function(){
		$(this).children("ul").not(":first").hide();
	});
	$(".subLevel_two").find(".nav_inner_banner_left").find("li").mouseover(function(){
		if($(".nav_inner_banner_right").children("ul").length>1)
		{
			var thisElemIndex=$(this).index();
			$(".nav_inner_banner_right").children("ul").eq(thisElemIndex).show().siblings("ul").hide();
		}
	});
	
	
	/** Lead Form Iframe SRC starts **/
	//var iframeSrc="http://122.169.118.65/samba/en/"+$(
	
	$(".leadFormIframe").attr("name");
	//var iframeSrc="https://solsadev.samba.com/samba/ar/";
	//var iframeSrcLocateUs="http://solsadev.samba.com/samba/ar/";
	var iframeSrc="";
	var iframeSrcLocateUs="";
	var iframeSrcLeadform="http://www.samba.com/samba/ar/";
	//var iframeSrc="http://122.169.118.65:91/samba/ar/";
	var leadFormIframeSrc=iframeSrcLeadform+$(".leadFormIframe").attr("name");
	$(".leadFormIframe").attr("src",leadFormIframeSrc);
	
	$(".applyNow").click(function(){
		var selectedValue = $(".homeBtm select").find("option:selected").attr("rel");
		$(this).attr("href",iframeSrc+selectedValue);
	});
	
	/*$(".buttons_dark").click(function(){
		var thisHref = $(this).attr("href");
		
		$(this).attr("href",iframeSrc+thisHref);
	});*/
	
	$(".buttons_dark,.jspPageURL").click(function(){
		var thisHref = $(this).attr("href");
		if(thisHref.indexOf("jsp")!=-1)
		{
			window.open(iframeSrc+thisHref);
			return false;
			//$(this).attr({"href":iframeSrc+thisHref,"target":"_blank"});
		}
	});
	
	var locationURL=window.location.href;
	if(locationURL.indexOf('locate-us')!=-1)
	{
		var oldSrc=$(".locateUsIframe").attr('src');
		if(locationURL.indexOf('?')!=-1)
		{
			locationURL=locationURL.split('?');			
			var newSrc=iframeSrcLocateUs+oldSrc+"?"+locationURL[1];
			$(".locateUsIframe").attr('src',newSrc);
		}
		else
		{
			var newSrc=iframeSrcLocateUs+oldSrc;
			$(".locateUsIframe").attr('src',newSrc);
		}		
	}
	/** Lead Form Iframe SRC ends **/
	
	/** For auto opening an accordion on the page **/
	var locationURL=window.location.href;
	if(locationURL.indexOf("?")!=-1)
	{
		locationURL=locationURL.split("?");
		if(locationURL[1].indexOf('select')!=-1)
		{
			var selectOptionParam=locationURL[1].substr(locationURL[1].indexOf('=')+1);
			
			if($("#"+selectOptionParam).length)
			{
				$("#"+selectOptionParam).click(function(){
					$(this).attr("selected","selected").siblings("option").removeAttr("selected");
					$("#faqs_dropdown").change()
				});
				$("#"+selectOptionParam).click();
			}
		}
		else
		{
			if($("#"+locationURL[1]).length)
	  		{
	  			$("#"+locationURL[1]).addClass("active").siblings("h3").removeClass("active");
	  			$("#"+locationURL[1]).next(".accordion_content").slideDown().siblings(".accordion_content").slideUp();
	  			$("html,body").animate({
	  				scrollTop:$("#"+locationURL[1]).offset().top
	  			},2000);
	  		}
		}
	}
	else
	{
		//$(".accordion").eq(0).children("h3").eq(0).addClass("active");
		//$(".accordion").eq(0).children("h3").eq(0).next(".accordion_content").slideDown();
	}
	/** For auto opening an accordion on the page ends **/	
	
/* Compare Card Next/Prev Functionality START */
$('.cardCarouselWrapper .next').click(function(){
	var carousLength = $('.carousel:visible').find('li').length;
	//alert("Next" + carousLength)
	if( $('.carousel:visible').find('.roundabout-in-focus').index()==carousLength-1)
	{
		$('.carousel:visible').find('li').eq(0).click();
	}
	else
	{
		$('.carousel:visible').find('.roundabout-in-focus').next().click();
	}
});

$('.cardCarouselWrapper .prev').click(function(){
	var carousLength = $('.carousel:visible').find('li').length;
	//alert("Prev" + carousLength)
	if($('.carousel:visible').find('.roundabout-in-focus').index()==0)
	{
		$('.carousel:visible').find('li').eq(carousLength-1).click();
	}
	else
	{
		$('.carousel:visible').find('.roundabout-in-focus').prev().click();
	}
});
/* Compare Card Next/Prev Functionality END */

/* Compare Card Tab Functionality START */

	if($(".cardCarouselWrapper").find('.carousel').length)
	{
		setTimeout(function(){
			$(".cardCarouselWrapper").find('.carousel').each(function(){
				if(!$(this).hasClass("noRoundAbout"))
				{
					$(this).roundabout({childSelector:".carousel li", minOpacity:1 });
				}
			}).promise().done(function(){$(this).find('img').draggable({ revert: "invalid", helper: 'clone' });});
		},500);
	}


$(".cardTabWrapper li").click(function(){
	if(!$(this).hasClass("sel"))
	{
		var thisIndex = $(this).index();
		$(this).addClass("sel").siblings().removeClass("sel");
		//$(".cardCarouselWrapper").eq(thisIndex).show().siblings(".cardCarouselWrapper").hide();
		$(".carousel").eq(thisIndex).show().siblings(".carousel").hide();
		if($(this).hasClass("noRoundAboutContent"))
		{
			$(".cardTitle").hide();
			$('.cardCarouselWrapper .prev, .cardCarouselWrapper .next').hide();
		}
		else
		{
			$(".cardTitle").show();
			$('.cardCarouselWrapper .prev, .cardCarouselWrapper .next').show();
			$(".cardTitle").html($(".cardCarouselWrapper").children(".carousel").eq(thisIndex).children(".roundabout-in-focus").children("img").attr("alt"));
		}
	}
}).eq(0).click();
/* Compare Card Tab Functionality END */	

/*popuop start*/
     $(".pop li").eq(3).click(function(){
		 //alert(1)
	  $(".p_box, #lightbox1").fadeIn();
	  
	  var popwidth = $(window).width();
	  var popheight = $(window).height();
	  var popscrolltop = $("html,body").scrollTop();
	  
	  $("#lightbox1").css("left",(popwidth-$("#lightbox1").width())/2+"px");
	  $("#lightbox1").css("top",(popheight-$("#lightbox1").height())/2+popscrolltop+"px")

	});	
	
	$(".p_box, .close, .p-button").click(function(){
		$(".p_box, #lightbox1").fadeOut();					   
	});
	
	$(".p-button").click(function(){
		window.open('https://careers.samba.com','_blank');				   
	});
	/*popup end*/

});



