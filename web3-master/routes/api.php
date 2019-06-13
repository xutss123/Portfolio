<?php

use Illuminate\Http\Request;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::middleware('auth:api')->get('/user', function (Request $request) {
    return $request->user();
});
Route::get('/house/{id}/favorite', 'OfferController@makefavorite');

Route::get('/people', 'APIController@index'); // get all
Route::post('/people/new', 'APIController@store'); // create
Route::get('/people/{user}', 'APIController@get'); // get one
Route::post('/people/{user}/update', 'APIController@update'); // update
Route::post('/people/{user}/delete', 'APIController@destroy'); // delete