var addListModel = function (a) {
    var self = this;
    self.data = ko.observableArray([]);
    self.departments = ko.observableArray(a.Departments);
    self.languages = ko.observableArray(a.Languages);
    self.Names = ko.observableArray(a.Names);

    $('#FirstName').autocomplete({
        source: self.Names()
    });
}