<?php

namespace App\Http\Controllers;

use \App\User;
use Illuminate\Http\Request;
use App\Exports\UsersExport;
use Maatwebsite\Excel\Facades\Excel;

class PeopleController extends Controller
{
    function index(){
        return view('people', [
            'data' => User::all()
        ]);
    }

    function export(){
        return Excel::download(new UsersExport, 'users.xlsx');
    }
}
