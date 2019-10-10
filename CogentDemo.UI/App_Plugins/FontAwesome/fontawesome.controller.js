angular.module("umbraco")
    .controller("CogentDemo.fontawesomeController",
        function ($scope) {
            //empty for now
        });

angular.module('umbraco')
    .directive('fontAwesome', function (assetsService) {
        return {
            restrict: 'C', //matches class 'font-awesome'
            link: function (scope, el, attrs) {

                var PLUGIN_PATH = "/App_Plugins/FontAwesome";

                assetsService.load([
                    PLUGIN_PATH + '/lib/select2/select2.min.js?c=7',
                ])
                    .then(function () {
                        var format = function (value) {
                            return '<i class="fa ' + value.text + '"></i> ' + value.text;
                        },
                            options = {
                                formatSelection: format,
                                formatResult: format,
                                escapeMarkup: function (m) { return m; },
                                width: 'element',
                                allowClear: true,
                                placeholder: "None"
                            };

                        //Ensure the custom select box loads after the first Angular digest
                        //so that the initial value matches model.value
                        setTimeout(function () {
                            $(el).select2(options);
                        }, 0);
                    });

                assetsService.loadCss(PLUGIN_PATH + '/lib/select2/select2.css?c=7');
                assetsService.loadCss(PLUGIN_PATH + '/lib/fontawesome/css/font-awesome.min.css?c=1');
                assetsService.loadCss(PLUGIN_PATH + '/fontawesome.css?c=7');
            }
        };
    });