"use client";

import FilterBarResearch from "../component/filterresearch";
import Search from "../component/search";
import Table from "../component/table";

export default function Course() {

    const singleFakeData = {
        title: 'Algorithm and Data Structure',
        college: 'Swarthmore College',
        category: 'NS',
        instructor: 'Vasanta Chaganti',
        schedule: "Summer 2024"
      };

    const repeatedFakeData = Array(10).fill(singleFakeData);


  return (
    <div className="flex flex-col">
      

      {/* Body */}
      <div className="flex-grow px-28 mt-10">
        <div className="w-full">

          {/* Filter and search bar */}
          <div className="flex space-x-4 justify-between">
            <FilterBarResearch />
            <Search placeholder="Search for researches" />
          </div>

          <div className="mt-10">

            {/* Break line and result num */}
            <div className="relative">
              <h1 className="text-sm absolute top-1 right-0">Found: 210 Results</h1>
              <hr className="mt-3 text-gray-200" />
            </div>

            {/* Actual result */}
            <div className="mt-10">
              <Table data={repeatedFakeData}/>
            </div>

          </div>
        </div>
      </div>

    </div>
  );
}
