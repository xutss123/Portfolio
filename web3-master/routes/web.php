<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/dashboard', 'HomePageController@index');
Route::get('/someData', 'HomePageController@some');
Route::get('/allData', 'HomePageController@all');
Route::get('/profile', 'HomePageController@profile');
Route::post('/password', 'HomePageController@password');

Route::get('/', 'Auth\LoginController@showLoginForm')->name('login');
Route::post('/', 'Auth\LoginController@login');
Route::get('logout', 'Auth\LoginController@logout')->name('logout');

Route::get('register', 'Auth\RegisterController@showRegistrationForm')->name('register');
Route::post('register', 'Auth\RegisterController@register');

Route::get('/home', 'HomeController@index')->name('home');

Route::post('/offer/create', 'OfferController@store');
Route::get('/offer/create', 'OfferController@create');
Route::get('/offer/{id}/delete', 'OfferController@delete');
Route::get('/offer/{id}', 'OfferController@show');
Route::post('/offer/{id}', 'OfferController@update');
Route::get('/people', 'PeopleController@index');
Route::get('/people/export', 'PeopleController@export');

