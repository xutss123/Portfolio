@extends('master')

@section('content')
<div class="px-2 py-2">
        <table class="border border-black rounded">
                <thead>
                    <tr class="border-b border-black bg-grey-dark ">
                        <th class="uppercase tracking-wide">Address</th>
                        <th class="uppercase tracking-wide">Owner phone number</th>
                        <th class="uppercase tracking-wide">Description</th>
                        <th class="uppercase tracking-wide">View</th>
                        <th class="uppercase tracking-wide">Delete</th>
                        <th class="uppercase tracking-wide">Favorite</th>
                    </tr>
                </thead>
                <tbody>
                    @forEach($data as $house)
                        <tr class="border-b border-black">
                            <td>{{ $house['address'] }}</td>
                            <td>{{ $house['owner_phone_nr'] }}</td>
                            <td>{{ $house['description'] }}</td>
                            @if(Auth::user()->id == $house['user_id'])
                            <td class="px-4 py-2"><a href="/offer/{{ $house['id'] }}/delete" class="no-underline rounded px-4 py-2 text-red-darkest bg-red-light uppercase font-bold tracking-wide">Delete</a></td>
                            <td class="px-4 py-2"><a href="/offer/{{ $house['id'] }}" class="no-underline rounded px-4 py-2 text-blue-darkest bg-blue-light uppercase font-bold tracking-wide">View</a></td>
                            @else
                            <td></td>
                            <td></td>
                            <td class="px-4 py-2"><a href="/offer/{{$house['id']}}/makefavorite" class="no-underline rounded px-4 py-2 text-yellow-darkest bg-yellow-light uppercase font-bold tracking-wide">favorite</a>
                            @endif
                        </tr>
                    @endForEach
                </tbody>
            </table>
</div>
@endsection
