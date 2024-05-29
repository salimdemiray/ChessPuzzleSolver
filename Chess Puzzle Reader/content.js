// Bu betik her sayfada çalışır
// Sayfaya doğrudan düğme ve span eklemek için değiştirebilirsiniz

// Sayfada "noprint puzzleButtons" sınıfına sahip div'i bul

function FindCellIndex(val) {
	let x = (parseInt(val) - 5) / 30;
	return x;
}

function WriteLetter(cellIndex) {
	return String.fromCharCode(65 + cellIndex);
}

function Write(div) {
	var c = {
		class: div.className,
		left: FindCellIndex(div.style.left),
		top: FindCellIndex(div.style.top)
	};
	let tas = c.class;

	switch (c.class) {
		case "icon-wp":
			tas = "P";
			break;
		case "icon-wr":
			tas = "K";
			break;
		case "icon-wn":
			tas = "A";
			break;
		case "icon-wb":
			tas = "F";
			break;
		case "icon-wq":
			tas = "V";
			break;
		case "icon-wk":
			tas = "Ş";
			break;
	}
	return WriteLetter(c.left) + (8 - c.top) + ":" + tas;
}


function solve() {
	const boardGameDivs = document.querySelectorAll('.board-pieces div');
	let results = Array.from(boardGameDivs).map(div => Write(div));

	console.log(results);

	return "Tahta > " + results.join(";");
}

function FindMeClick() {
	// noprint puzzleButtons sınıfına sahip div'i bul
	const helloSpan = document.querySelector("#resultSpan");

	if (helloSpan) {
		helloSpan.textContent = solve();
	}
}

const targetDiv = document.querySelector(".noprint.puzzleButtons");

if (targetDiv) {
	
	let moveText=document.querySelector("#moveText");
	
	if(!moveText)
	{
		moveText=document.createElement("input");
		moveText.id="moveText";
		moveText.type = "text";
		moveText.style.width="400px";
		targetDiv.appendChild(moveText);
		//<input id="moveText" type="text" style="width: 400px;">
	}
	
	
	// Sayfaya bir düğme ve bir span ekle
	let button = document.querySelector("#findButton");
	if (!button) {							
		button = document.createElement("button");
		button.id = "findButton";
		button.textContent = "Tahtayi Oku";
		button.type = "button";
		targetDiv.appendChild(button);
	}
	button.onclick = FindMeClick;

	let span = document.querySelector("#resultSpan");

	if (!span) {
		span = document.createElement("span");
		span.id = "resultSpan";
		targetDiv.appendChild(span);
	}

} else {
	console.error("Hedef div bulunamadı.");
}




