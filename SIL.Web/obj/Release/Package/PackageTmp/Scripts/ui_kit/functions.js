$(document).ready(function(){
	tables();
	
	tabs();
	
	mainMenu();	
	
	tooltip();
});

function tables(){
	$('table tr:even').addClass('alt');
}

function tabs(){
	$('.tabs').tabs();
}

function mainMenu(){
	/*$('#mainMenu > ul > li').mouseenter(function(){
		$(this).children('.subMenu').show();
	});
	
	$('#mainMenu .subMenu').mouseleave(function(){
		$(this).hide();
	});	*/

	$('#mainMenu > ul').dropdown_menu();

}

function tooltip(){
	$('.tooltip').tooltipster({
		position:'right',
		interactive:true
	});
	
	$('.tooltip-red').tooltipster({
		theme: '.tooltipster-theme-red',
		position: 'right'
	});
	
}