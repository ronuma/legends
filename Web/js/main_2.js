// Main JavaScript file for the website
// By Iker Garcia German
// Version 2.0
// Last update: 2023-04-16

// Add scrollmagic controller
let controller = new ScrollMagic.Controller();

//--------------------------//
//-- Anime JS animations --//
//------------------------//

// Main logo animation (first animation)
var animation1 = anime({
    targets: '.logobackmain',
    scale: [0, 1],
    rotateZ: {
      value: 360,
      duration: 15000,
    },
    opacity: [0, 1],
    duration: 2000,
    easing: 'linear',
    loop: false,
    begin: () => {
      animation2.play();
    },
    complete: () => {
        animation3.play();
      }
  });
let animation2 = anime({
    targets: '.logomain',
    scale: [0, 1],
    duration: 2000,
    autoplay: false,
    loop: false,
    easing: 'linear'
  });
let animation3 = anime({
    targets: '.logobackmain',
    rotateZ: 360,
    scale: [1, .75],
    duration: 15000,
    autoplay: false,
    easing: 'linear',
    complete: () => {
      animation4.play();
    }
  });
  let animation4 = anime({
    targets: '.logobackmain',
    rotateZ: 360,
    scale: [.75, 1],
    duration: 15000,
    autoplay: false,
    easing: 'linear',
    complete: () => {
      animation3.play();
    }
  });

// Main logo animation (svg polymorphing)

anime({
    targets: '.logobackmain .poly1',
    points: [
      { value: [
        '448 310 552 310 500 500',
        '448 250 552 250 500 500']
      },
      { value: '448 400 552 400 500 500' },
      { value: '448 230 552 230 500 500' },
      { value: '448 310 552 310 500 500' }
    ],
    easing: 'easeInOutSine',
    duration: 15000,
    loop: true
  });
anime({
    targets: '.logobackmain .poly2',
    points: [
      { value: [
        '516.2 336.89 620.2 336.89 568.2 526.89',
        '516.2 200.89 620.2 200.89 568.2 526.89']
      },
      { value: '516.2 400.89 620.2 400.89 568.2 526.89' },
      { value: '516.2 600.89 620.2 600.89 568.2 526.89' },
      { value: '516.2 336.89 620.2 336.89 568.2 526.89' }
    ],
    easing: 'easeInOutSine',
    duration: 18000,
    loop: true
  });
anime({
    targets: '.logobackmain .poly3',
    points: [
      { value: [
        '543 403.917 647 403.917 595 593.917',
        '543 590.917 647 590.917 595 593.917']
      },
      { value: '543 200.917 647 200.917 595 593.917' },
      { value: '543 590.917 647 590.917 595 593.917' },
      { value: '543 403.917 647 403.917 595 593.917' }
    ],
    easing: 'easeInOutSine',
    duration: 12000,
    loop: true
  });
anime({
    targets: '.logobackmain .poly4',
    points: [
      { value: [
        '448 500 552 500 500 690',
        '448 560 552 560 500 690']
      },
      { value: '448 580 552 580 500 690' },
      { value: '448 400 552 400 500 690' },
      { value: '448 500 552 500 500 690' }
    ],
    easing: 'easeInOutSine',
    duration: 5000,
    loop: true
  });
  anime({
    targets: '.logobackmain .poly5',
    points: [
      { value: [
        '516.2 661.563 620.2 661.563 568.2 471.563',
        '516.2 516.563 620.2 516.563 568.2 471.563']
      },
      { value: '516.2 700.563 620.2 700.563 568.2 471.563' },
      { value: '516.2 550.563 620.2 550.563 568.2 471.563' },
      { value: '516.2 661.563 620.2 661.563 568.2 471.563' }
    ],
    easing: 'easeInOutSine',
    duration: 7500,
    loop: true
  });
  anime({
    targets: '.logobackmain .poly6',
    points: [
      { value: [
        '353 593.917 457 593.917 405 403.917',
        '353 690.917 457 690.917 405 403.917']
      },
      { value: '353 550.917 457 550.917 405 403.917' },
      { value: '353 620.917 457 620.917 405 403.917' },
      { value: '353 593.917 457 593.917 405 403.917' }
    ],
    easing: 'easeInOutSine',
    duration: 5000,
    loop: true
  });
  anime({
    targets: '.logobackmain .poly7',
    points: [
      { value: [
        '379.755 471.562 483.755 471.562 431.755 661.563',
        '379.755 600.562 483.755 600.562 431.755 661.563']
      },
      { value: '379.755 300.562 483.755 300.562 431.755 661.563' },
      { value: '379.755 590.562 483.755 590.562 431.755 661.563' },
      { value: '379.755 471.562 483.755 471.562 431.755 661.563' }
    ],
    easing: 'easeInOutSine',
    duration: 6500,
    loop: true
  });
  anime({
    targets: '.logobackmain .poly8',
    points: [
      { value: [
        '379.756 526.893 483.756 526.893 431.756 336.89',
        '379.756 350.893 483.756 350.893 431.756 336.89']
      },
      { value: '379.756 500.893 483.756 500.893 431.756 336.89' },
      { value: '379.756 390.893 483.756 390.893 431.756 336.89' },
      { value: '379.756 526.893 483.756 526.893 431.756 336.89' }
    ],
    easing: 'easeInOutSine',
    duration: 10000,
    loop: true
  });


//--------------------//
// -- ScrollMagic -- //
//------------------//

// Hero Section

let scene1 = new ScrollMagic.Scene({
  triggerElement: "#two",
  triggerHook: 0.06,
  duration: "110%"
})
.setPin("#two")
// Add debug indicators fixed on right side
.addIndicators({
  colorTrigger: "white",
  colorStart: "blue",
  colorEnd: "red",
  indent: 10
})
.addTo(controller);

// --------------------- //
// -- Simple Parallax -- //
// --------------------- //

// First IMG
var image = document.getElementsByClassName('img1-parallax');
new simpleParallax(image, {
	scale: 2,
  delay: .6,
  transtition: 'cubic-bezier(0,0,0,.56)'
});

// ------------------- //
// -- Letterize.js -- //
// ----------------- //

const obj = new Letterize({
  targets: document.getElementById("letterizeMe"),
  wrapper: "b",
  className: "letter"
});
obj.listAll;
for (var i = 0; i < obj.listAll.length; i++) {
  obj.listAll[i].addEventListener("mouseover", function(e) {
      e.target = anime({
          targets: e.target,
          duration: 100,
          translateX: anime.random(-10,10),
          translateY: anime.random(-10,10),
          rotate: anime.random(-10,10),
          opacity: 0.5
      });
  });
  obj.listAll[i].addEventListener("mouseout", function(e) {
      e.target = anime({
          targets: e.target,
          duration: 3000,
          opacity: 1
      });
  });
}