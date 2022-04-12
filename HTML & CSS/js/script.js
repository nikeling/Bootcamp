
//MUSHROOM-INDEX

    var mod = document.getElementById('MOD');
    var mushroomList = ["Amanita Muscaria", "Boletus Satanus",
                "Amanita Casarea", "Russula"];

  
         
    function showMushroom() {
        document.getElementById('mod').innerHTML = mushroomList[Math.floor(Math.random() * mushroomList.length)];
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

   const fname = document.forms["myForm"]["fname"].value;
   const lname = document.forms["myForm"]["lname"].value;
   const email = document.forms["myForm"]["email"].value;

    // document.getElementById('data').innerHTML = `Firstname: ${fname}
    //        <br> Lastname: ${lname}
    //      <br> Email: ${email}`;

    let listOfUsers= [
      { firstname: 'John',
        lastname: 'Smith',
        email: 'nnn@gmail.com'
      },
      {firstname: 'Peter',
      lastname: 'Redd',
      email: 'nmn@gmail.com'}
    ];

    let newUser = {
      firstname: fname,
      lastname: lname,
      email: email,
    }

    //add to list
    listOfUsers.push(newUser);
    document.getElementById('data').innerHTML = JSON.stringify(listOfUsers);

    

    
}



