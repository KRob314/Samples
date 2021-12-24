(function ()
{
    'use strict';
    angular.module('homeCinema', ['common.core', 'common.ui']).config(config);
    config.$inject = ['$routeProvider'];

    function config($routeProvider)
    {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/index.html",
                controller: "indexCtrl"
            })
            .when("/login", {
                templateUrl: "scripts/spa/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html",
                controller: "registerCtrl"
            })
            .when("/customers", {
                templateUrl: "scripts/spa/customers/index.html",
                controller: "customersCtrl"
            })
            .when("/customers/register", {
                templateUrl: "scripts/spa/customers/register.html",
                controller: "customersRegCtrl"
            })
            .when("/moviesubmission", {
                templateUrl: "scripts/spa/movieSubmission/index.html",
                controller: "movieSubmissionCtrl"
            })
            .when("/moviesubmission/add", {
                templateUrl: "scripts/spa/movieSubmission/add.html",
                controller: "movieSubmissionAddCtrl"
            })
            .when("/moviesubmission/:id", {
                templateUrl: "scripts/spa/movieSubmission/details.html",
                controller: "movieSubmissionDetailsCtrl"
            })
            .when("/moviesubmission/edit/:id", {
                templateUrl: "scripts/spa/movieSubmission/edit.html",
                controller: "movieSubmissionEditCtrl"
            })
            .when("/rental", {
                templateUrl: "scripts/spa/rental/index.html",
                controller: "rentStatsCtrl"
            }).otherwise({ redirectTo: "/" });
    }
})();
