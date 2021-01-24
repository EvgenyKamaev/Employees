var employeListModel = function (a) {
    var self = this;
    self.allData = ko.observableArray([]);
    self.currentData = ko.observableArray([]);
    self.selectedEmploye = ko.observable();

    self.allData(a);

    if (self.allData().length >= 5) {
        for (let i = 0; i < 5; i++) {
            self.currentData.push(self.allData()[i]);
            if (i == 4)
                self.allData.splice(0, 5);
        };
    }
    else {
        self.currentData(self.allData());
        self.allData([]);
    }
    return {
        showMore: function () {
            if (self.allData().length <= 5) {
                for (let i = 0; i <= self.allData().length; i++) {
                    self.currentData.push(self.allData()[i]);
                    if (i == self.allData().length - 1)
                        self.allData([]);
                };
            }

            else {
                for (let i = 0; i < 5; i++) {
                    self.currentData.push(self.allData()[i]);
                    if (i == 4)
                        self.allData.splice(0, 5);
                };
            }
        },
        showInfo: function (info) {
            $.ajax({
                url: '/Review/ShowInfo',
                type: 'POST',
                data: info.ReviewInfo,
                success: function (result) {
                    window.location.href = result.redirectUrl;
                }
            })
        },
        selectEmploye: function (id) {
            if (self.selectedEmploye() !== null && self.selectedEmploye() !== '')
                self.selectedEmploye(null);
            self.selectedEmploye(id);
        },
        deleteEmploye: function () {
            $.ajax({
                url: '/Home/DeleteEmploye?employeId=' + self.selectedEmploye().Id,
                type: 'GET',
                success: function () {
                    const index = self.currentData.indexOf(self.selectedEmploye());
                    if (index > -1) {
                        self.currentData.splice(index, 1);
                    };
                }
            })
        },
        addEmploye: function () {
            $.ajax({
                url: '/Home/AddEmploye',
                type: 'POST',
                data: info.ReviewInfo,
                success: function () {
                    console.log(1);
                }
            })
        }
    };
}
