// *********  Typed.JS JQuery Plugin *********

var typed = new Typed('.anim', {
    // Waits 1000ms after typing "First"
    strings: [
        '',
        'Azure Cloud Administrator',
        'Azure Cloud Developper',
        'Azure DevOps Engineer',
        'Certified Kubernetes Administrator',
        'Certified Terraform Associate'
    ],
    typeSpeed: 50,
    backSpeed: 50,
    cursorChar: '_',
    loop: true,
});

var type = new Typed('.automatisation', {
    strings: [
        'Bash',
        'PowerShell',
        'AzCLI'
    ],
    typeSpeed: 0,
    backSpeed: 0,
    cursorChar: '_',
    shuffle: false,
    smartBackspace: false,
    loop: true
});

var typeing = new Typed('.monitor', {
    strings: [
        'Prometheus',
        'Grafana',
        'Key Vaults',
        'Backups'
    ],
    typeSpeed: 0,
    backSpeed: 0,
    cursorChar: '_',
    shuffle: false,
    smartBackspace: false,
    loop: true
});

var typex = new Typed('.cicd', {
    strings:[
        'Accelerating application development and deployment lifecycles.',
        'Building quality and consistency into an automated build and release process.',
        'Increasing application stability and uptime.'
    ],
    typeSpeed: 20,
    backSpeed: 0,
    cursorChar: '_',
    loop: true
});