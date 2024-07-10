// *********  Typed.JS JQuery Plugin *********

var typed = new Typed('.anim', {
    // Waits 1000ms after typing "First"
    strings: [
        '',
        'Azure Cloud Administrator',
        'Azure Cloud Developper',
        'Azure Cloud DevOps',
        'Web Developper',
        'Game Designer',
        'Game Developper',
        'Graphic Designer'
        ],
    typeSpeed:50,
    backSpeed:50,
    cursorChar: '_',
    loop:true,
});

var type = new Typed('.design', {
    strings: [
        'Terraform',
        'Ansible'
    ],
    typeSpeed: 0,
    backSpeed: 0,
    cursorChar: '_',
    shuffle: true,
    smartBackspace: false,
    loop: true
});

var typex = new Typed('.azure', {
    strings: [
        'Boards',
        'Repos',
        'Pipelines',
        'Test Plans',
        'Artifacts'
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
        'Prometheus',
        'Grafana',
        'Key Vaults',
        'Backups'
    ],
    typeSpeed: 50,
    backSpeed: 50,
    cursorChar: '_',
    shuffle: true,
    smartBackspace: false,
    loop: true
});

