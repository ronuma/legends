var image = document.getElementsByClassName('back-img');
        new simpleParallax(image, {
	        orientation: 'up',
            overflow: true,
            scale: 2,
            delay: .6,
        });
        var image2 = document.getElementsByClassName('back-img2');
        new simpleParallax(image2, {
	        orientation: 'down',
            scale: 1.5,
            delay: .6,
	        transition: 'cubic-bezier(0,0,0,1)'
        });
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