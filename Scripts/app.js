var ViewModel = function () {
    var self = this;
    self.goods = ko.observableArray();
    self.detail = ko.observable();
    self.error = ko.observable();

    var goodsUri = '/api/goods/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllGoods() {
        ajaxHelper(goodsUri, 'GET').done(function (data) {
            self.goods(data);
        });
    }

    self.getGoodDetail = function (item) {
        ajaxHelper(goodsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    // Fetch the initial data.
    getAllGoods();
};

ko.applyBindings(new ViewModel());