








//Funkcni



//fetch("/User/Collection/GetAll").then(response => response.json())
//    .then(data => info = data).then(infoZob);





function AppViewModel() {
    var self = this;

    
    self.Load = function() {
        console.log('happy');
    }

    self.Load();
    
}

ko.applyBindings(new AppViewModel());
