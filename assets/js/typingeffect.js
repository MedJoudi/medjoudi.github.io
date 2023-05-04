// *********  Typed.JS JQuery Plugin *********

var typed = new Typed('.anim', {
    // Waits 1000ms after typing "First"
    strings: [
        '',
        'Web Designer',
        'Web Developper',
        'Game Designer',
        'Game Developper',
        'Graphic Designer'
        ],
    typeSpeed:100,
    backSpeed:100,
    cursorChar: '_',
    loop:true,
});

var type = new Typed('.design', {
    strings: [
        'HTML',
        'CSS',
        'JavaScript',
        'PHP',
        'SQL'
    ],
    typeSpeed: 0,
    backSpeed: 0,
    cursorChar: '_',
    shuffle: true,
    smartBackspace: false,
    loop: true
});

var typex = new Typed('.illustrate', {
    strings: [
        'PhotoShop',
        'Ilustrator',
        'Premier Pro'
    ],
    typeSpeed: 0,
    backSpeed: 0,
    cursorChar: '_',
    shuffle: true,
    smartBackspace: false,
    loop: true
});

var typez = new Typed('.code', {
    strings: [
        'Python',
        'C#',
        'TypeScript',
    ],
    typeSpeed: 0,
    backSpeed: 0,
    cursorChar: '_',
    shuffle: true,
    smartBackspace: false,
    loop: true
});