
//MUSHROOM-INDEX

    var mod = document.getElementById('MOD');
    var mushroomList = ["Amanita Muscaria", "Boletus Satanus",
                "Amanita Casarea", "Russula"];
         
    function showMushroom() {
        document.getElementById('mod').innerHTML = list[Math.floor(Math.random() * list.length)];
        }

    function changeColour(){
        if (document.getElementById("body").getAttribute("class") == "body"){
            document.getElementById("body").removeAttribute("class");
        } document.getElementById("body").setAttribute("class", "body");
        
    } 

    
      const list = document.getElementById('list');
      const input = document.getElementById('item');
      const button = document.getElementById('addToList');

      button.addEventListener('click', () => {
        const myItem = input.value;
        input.value = '';
        
        const listItem = document.createElement('li');
        const listText = document.createElement('span');
        const listBtn = document.createElement('button');

        listItem.appendChild(listText);
        listText.textContent = myItem;
        listItem.appendChild(listBtn);
        listBtn.textContent = 'Delete';
        document.getElementById('list').appendChild(listItem);

        listBtn.addEventListener('click', () => {
          list.removeChild(listItem);
        });
        document.getElementById('item')=

        input.focus();
      });
    

// AMANITA 

function showData(){
    document.getElementById('data').innerHTML = `Firstname: ${document.forms["myForm"]["fname"].value}
           <br> Lastname: ${document.forms["myForm"]["lname"].value}
         <br> Email: ${document.forms["myForm"]["email"].value}`;
}



