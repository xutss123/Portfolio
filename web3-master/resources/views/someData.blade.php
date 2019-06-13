@extends('master')

@section('content')
<div class="px-2 py-2">
    <table class="border border-black rounded">
        <thead>
            <tr class="border-b border-black bg-grey-dark ">
                <th class="uppercase tracking-wide">Address</th>
                <th class="uppercase tracking-wide">Description</th>
            </tr>
        </thead>
        <tbody>
            @forEach($data as $house)
                <tr class="border-b border-black">
                    <td>{{ $house['address'] }}</td>
                    <td>{{ substr($house['description'], 0, 100) }}</td>
                </tr>
            @endForEach
        </tbody>
    </table>
</div>
@endsection
