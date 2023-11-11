"use client";

import NavBar from "../component/navbar";
import FilterBar from "../component/filter";
import Search from "../component/search";
import Card from "../component/table";
import Footer from "../component/footer";

export default function Course() {

  const singleFakeData = {
    title: 'Algorithm and Data Structure',
    college: 'Swarthmore College',
    category: 'NS',
    instructor: 'Vasanta Chaganti',
    schedule: 'TTH 1:15pm - 2:25pm',
    rating: '9/10',
    room: 'SCI 256',
  };

const repeatedFakeData = Array(10).fill(singleFakeData);

  return (
    <div className="flex flex-col">
      

      {/* Body */}
      <div className="flex-grow px-28 mt-10">
        <div className="w-full">

          {/* Filter and search bar */}
          <div className="flex space-x-4 justify-between">
            <FilterBar />
            <Search placeholder="Search courses"/>
          </div>

          <div className="mt-10">

            {/* Break line and result num */}
            <div className="relative">
              <h1 className="text-sm absolute top-1 right-0">Found: 210 Results</h1>
              <hr className="mt-3 text-gray-200" />
            </div>

            {/* Actual result */}
            <div className="mt-10">
              <Card data={repeatedFakeData}/>
            </div>

          </div>
        </div>
      </div>

    </div>
  );
}
