








var myButton = document.getElementById('my-button'),
	
	myInput = document.getElementById('my-input');

myButton.onclick = function () {
	
	'use strict';
	
	if (this.textContent === 'show password') {
		myInput.setAttribute('type', 'text');
		this.textconent = 'Hide Password';
	} else {
		myInput.setAttribute('type', 'password');
		this.textContent = 'Show Password';
		
	}
	
};
