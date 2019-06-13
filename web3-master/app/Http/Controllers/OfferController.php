<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;

class OfferController extends Controller
{
    public function __construct()
    {
        $this->middleware('auth');
    }

    public function show($id){
        return view('offer', [
            'house' => \App\House::find($id)
        ]);
    }

    public function delete($id){
        \App\House::destroy($id);
        return \Redirect::back();
    }

    public function create(){
        return view('create');
    }

    public function update(Request $request, $id){
        $house = \App\House::find($id);

        $rules = array(
            'address'          => 'required|string',
            'description'          => 'required|string',
            'number' => 'required|string'
        );

        $validator = \Validator::make($request->all(), $rules);

        if ($validator->fails())
        {
            return \Redirect::back()->withErrors($validator);
        }

        $house->update($request->all());

        return \Redirect::back();
    }
    public function makefavorite(Request $request, $id){
        $house = \App\House::find($id);

        $house->update(['is_favorite'=>!$this->is_favorite]);
    }

    public function store(Request $request){
        $rules = array(
            'address'          => 'required|string',
            'description'          => 'required|string',
            'price'         =>'required',
            'owner_phone_nr' => 'required'
        );

        $validator = \Validator::make($request->all(), $rules);

        if ($validator->fails())
        {
            return \Redirect::back()->withErrors($validator);
        }
        $house = \App\House::create(array_merge($request->all(), [
            'lease_start' => \Carbon\Carbon::now(),
            'is_favorite' => false,
            'user_id' => \Auth::user()->id
        ]));

        return redirect('/offer' . '/' . $house->id);
    }
}
