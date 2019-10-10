﻿angular.module("umbraco").controller("Navigation.NavigationEditController",
    function ($scope, $routeParams, approvalResource, notificationsService, navigationService) {

        $scope.loaded = false;

        if ($routeParams.id == -1) {
            $scope.node = {};
            $scope.loaded = true;
        }
        else {
            navigationResource.getById($routeParams.id).then(function (response) {
                $scope.node = response.data;
                $scope.loaded = true;
            });
        }

        $scope.publish = function (node) {
            navigationResource.publish(node.Id).then(function (response) {
                $scope.node = response.data;
                $scope.contentForm.$dirty = false;
                navigationService.syncTree({ tree: 'navigationTree', path: [-1, -1], forceReload: true });
                notificationsService.success("Success", node.Name + " has been added to the navigation");
            });
        };

    });