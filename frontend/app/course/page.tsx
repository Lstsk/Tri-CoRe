"use client";

import { use, useEffect, useState } from "react";
import FilterBar from "../component/filter";
import Search from "../component/search";
import Card from "../component/table";

export default function Course() {

  const singleFakeData = {
    title: 'Algorithm and Data Structure',
    college: 'Swarthmore College',
    category: 'NS',
    instructor: 'Vasanta Chaganti',
    schedule: 'TTH 1:15pm - 2:25pm',
    rating: '9/10',
    room: 'SCI 256',
    max_enrollment: 19
  };

const repeatedFakeData = Array(10).fill(singleFakeData);

const [filter, setFilter] = useState<string[]>([])
const [filterData, setFilterData] = useState([])

const fetchDataWithFilters = async (filters: string[]) => {
  // Fetch data from API using the provided filters
  // Update the filterData state with the fetched data

  // const response = await fetch(`your-api-endpoint?${new URLSearchParams(filter).toString()}`);
  // const data = await response.json();
  // setFilterData(data);
}

  // Fetch data without filters initially
  useEffect(() => {
    const fetchInitialData = async () => {
      // Fetch data from API without filters
      const response = await fetch("your-api-endpoint");
      const data = await response.json();
      setFilterData(data);
    };

    fetchInitialData();
  }, []); // Empty dependency array ensures this effect runs only once on mount

  // Fetch data with filters when filter state changes
  useEffect(() => {
    fetchDataWithFilters(filter);
  }, [filter]);

  
  return (
    <div className="flex flex-col">
      <p className="text-xl px-28 mt-5 font-bold">Course Page</p>


      {/* Body */}
      <div className="flex-grow px-28 mt-5">

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
