angular.module("umbraco.resources")
    .factory("navigationResource", function ($http) {
        return {
            getById: function (id) {
                return $http.get("backoffice/Navigation/NavigationApi/GetById?id=" + id);
            },
            publish: function (id) {
                return $http.post("backoffice/Navigation/NavigationApi/PostPublish?id=" + id);
            }
        };
    });