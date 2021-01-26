var editModel = function (a) {
    var self = this;
    
    self.lastName = ko.observable(a.LastName);
    self.firstName = ko.observable(a.FirstName);
    self.age = ko.observable(a.Age);
    self.department = ko.observableArray([a.Department]);
    self.departments = ko.observableArray(a.Departments);
    self.languages = ko.observableArray(a.Languages);
    self.selectedLanguage = ko.observableArray([a.SelectedLanguage]);
}