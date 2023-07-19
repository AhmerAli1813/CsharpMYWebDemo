$(function () {

//    * Scroll top button
//    */
  const scrollTop = document.querySelector('.scroll-top');
  if (scrollTop) {
    const togglescrollTop = function() {
      window.scrollY > 100 ? scrollTop.classList.add('active') : scrollTop.classList.remove('active');
    }
    window.addEventListener('load', togglescrollTop);
    document.addEventListener('scroll', togglescrollTop);
    
  }
  scrollTop.addEventListener('click',()=>{
    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    })
  });

//  menu toggle function for sidebar
    $("#menu-toggle").click(function (e) { 
        var val =    getComputedStyle(document.documentElement).getPropertyValue('--sidebar-width'); // #999999
        
       
        if(val == "300px"){
            
           
                $(':root').css('--sidebar-width', "60px");
                $("#menu-toggle i").addClass("fas fa-arrow-right")
                $("#menu-toggle i").removeClass("fa-arrow-left");
                $(".dpanel-sidebar").addClass("active");
                $(".navbar-brand").css("padding", "0.5rem")
            }else{
                $(':root').css('--sidebar-width', '300px');
                $("#menu-toggle i").addClass("fa-arrow-left");
                $("#menu-toggle i").removeClass("fa-arrow-right");
                $(".dpanel-sidebar").removeClass("active");
                $(".navbar-brand").css("padding", "0.5rem 1.5rem")

            }
      
    });
    // navbar 
    $("#nav-menu-toggle").click(function (e) { 
        
        $(".dpanel-sidebar ul ul").toggleClass("active")
        
    });
    // search btn 
    $(".search-btn").click(function (e) { 
        e.preventDefault();
        $("#search-form").addClass("active");
        
    });
    
    $(".btn-close").click(function (e) { 
        e.preventDefault();
        $("#search-form").removeClass("active");
        
    });
//  dropDown function
$(".dropdown-menu").css("display" ,"none")

    $(".dropdown").click(function (e) { 

        // e.preventDefault();
        var dropdown_item = $(this).attr("data-dropdown");
        // alert(dropdown_item)
        $(dropdown_item).toggle("active");
        $(this).siblings().children(".caret").toggleClass('rotate-180');
        
        
    });

  // themes

  $("#color-gallery .color-item").click(function (e) { 
    let lst = window.localStorage;
    e.preventDefault();
    var hsl = $(this).data("hsl");
  var color_sts =  $(this).data("color-sts");
            lst.setItem("hsl" , hsl);
            lst.setItem("theme" , color_sts );
  theme();
});

function theme(){
let lst = window.localStorage;
    let hsl = lst.getItem("hsl");
    let theme = lst.getItem("theme");
    $(":root").css("--hue-color" , hsl );
    if(theme== "dark"){
      $(":root").css("--body-color" , `var(--bs-gray-800)`)   
      $(":root").css("--body-color-light" , `var(--bs-gray-dark)`)   
      $(":root").css("--text-color" , `white`)   
      
  }else {
      
      $(":root").css("--body-color" , `white`)
      $(":root").css("--body-color-light" , `#eee`)      
      $(":root").css("--text-color" , `var(--bs-dark)`)  
  }
}
theme();
// sidebar list hover  js 
let list = document.querySelectorAll(".sidebar-item");
function activeLink(){
    list.forEach((item) => {
        item.classList.remove("active")
        this.classList.add("active")
    });
}
list.forEach((item)=>{
    item.addEventListener("mouseover" , activeLink);
})
    //chrats js 

});
document.addEventListener('DOMContentLoaded', () => {
    "use strict";
  
    /**
     * Preloader
     */
    const preloader = document.querySelector('#preloader');
    if (preloader) {
      window.addEventListener('load', () => {
        preloader.remove();
      });
    }
  
    /**
     * Sticky header on scroll
     */
    const selectHeader = document.querySelector('.Main-Container') ,
          sidebar = document.querySelector('aside');
    if (selectHeader) {
      document.addEventListener('scroll', () => {
        window.scrollY > 0 ? selectHeader.classList.add('scroll-active') : selectHeader.classList.remove('scroll-active');
        if(window.scrollY >0){
          sidebar.classList.remove("active");
          $("#menu-toggle i").addClass("fa-arrow-left");
          $("#menu-toggle i").removeClass("fa-arrow-right");
          
        }else{
          $("#menu-toggle i").addClass("fas fa-arrow-right")
          $("#menu-toggle i").removeClass("fa-arrow-left");
        }
  
      });
    }
   
  
    /**
     * Navbar links active state on scroll
     */
    let navbarlinks = document.querySelectorAll('#navbar a');
  
    function navbarlinksActive() {
      navbarlinks.forEach(navbarlink => {
  
        if (!navbarlink.hash) return;
  
        let section = document.querySelector(navbarlink.hash);
        if (!section) return;
  
        let position = window.scrollY + 200;
  
        if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
          navbarlink.classList.add('active');
        } else {
          navbarlink.classList.remove('active');
        }
      })
    }
    window.addEventListener('load', navbarlinksActive);
    document.addEventListener('scroll', navbarlinksActive);
  
    /**
     * Mobile nav toggle
     */
    const mobileNavShow = document.querySelector('.mobile-nav-show');
    const mobileNavHide = document.querySelector('.mobile-nav-hide');
  
    document.querySelectorAll('.mobile-nav-toggle').forEach(el => {
      el.addEventListener('click', function(event) {
        event.preventDefault();
        mobileNavToogle();
      })
    });
  
    function mobileNavToogle() {
      document.querySelector('body').classList.toggle('mobile-nav-active');
      mobileNavShow.classList.toggle('d-none');
      mobileNavHide.classList.toggle('d-none');
    }
  
    /**
     * Hide mobile nav on same-page/hash links
     */
    document.querySelectorAll('#navbar a').forEach(navbarlink => {
  
      if (!navbarlink.hash) return;
  
      let section = document.querySelector(navbarlink.hash);
      if (!section) return;
  
      navbarlink.addEventListener('click', () => {
        if (document.querySelector('.mobile-nav-active')) {
          mobileNavToogle();
        }
      });
  
    });
  
    /**
     * Toggle mobile nav dropdowns
     */
    const navDropdowns = document.querySelectorAll('.navbar .dropdown > a');
  
    navDropdowns.forEach(el => {
      el.addEventListener('click', function(event) {
        if (document.querySelector('.mobile-nav-active')) {
          event.preventDefault();
          this.classList.toggle('active');
          this.nextElementSibling.classList.toggle('dropdown-active');
  
          let dropDownIndicator = this.querySelector('.dropdown-indicator');
          dropDownIndicator.classList.toggle('bi-chevron-up');
          dropDownIndicator.classList.toggle('bi-chevron-down');
        }
      })
    });
  
  
  });