"use client"

import { useState } from 'react';
import {AiTwotoneStar} from "react-icons/ai"


const fakeData = [
  {
    id: 1,
    title: 'Fake Event 1',
    date: '2023-11-15',
    host: "Swarthmore On",
    location: 'Swarthmore Hello',
  },
  {
    id: 2,
    title: 'Fake Event 2',
    date: '2023-11-20',
    host: "Swarthmore On",
    location: 'Swarthmore Parrish',
  },
  {
    id: 2,
    title: 'Fake Event 2',
    date: '2023-11-20',
    host: "Swarthmore On",
    location: 'Swarthmore Parrish',
  },
  {
    id: 2,
    title: 'Fake Event 2',
    date: '2023-11-20',
    host: "Swarthmore On",
    location: 'Swarthmore Parrish',
  },
  {
    id: 2,
    title: 'Fake Event 2',
    date: '2023-11-20',
    host: "Swarthmore On",
    location: 'Swarthmore Parrish',
  },

  // Add more fake events as needed
];


export default function Home() {
  const researchOpportunities = Array.from({ length: 7 });
  const courseRating = Array.from({ length: 7 });
  const [events, setEvents] = useState(fakeData);

  return (
    <div className="px-28 w-full mt-10">


    <div className='flex justify-between mb-5'>
      <div className='bg-white px-2'>
        <p className='text-md font-bold px-2 py-1 bg-[#bf3134] text-white  rounded'>Swarthmore Registration Deadline</p>
        <p>11/10/2023</p>
      </div>
      <div className='bg-white p-2'>
      <p className='text-md font-bold px-2 py-1 bg-[#FFF0BE] text-black  rounded'>Swarthmore Registration Deadline</p>
      </div>
      <div className='bg-white p-2'>
      <p className='text-md font-bold px-2 py-1 bg-[#8B0000] text-white rounded'>Swarthmore Registration Deadline</p>
      </div>    
      </div>


    <div className='bg-white border rounded border-gray-300 p-4 flex flex-col mb-5'>
      <p className='text-xl font-bold mb-4'>Rate Courses This Week</p>
      <div className='flex flex-row'>
        <div className="flex-1 flex flex-col mb-4 mr-4">
          <label htmlFor="course" className="mb-2 text-sm">Course</label>
          <input type="text" className='w-full p-2 border rounded text-sm focus:outline-none focus:ring focus:border-blue-500' name="course" id="course" placeholder='Enter Course Name'/>
        </div>
        <div className="flex-1 flex flex-col mb-4 mr-4">
          <label htmlFor="instructor" className="mb-2 text-sm">Instructor</label>
          <input type="text" className='w-full p-2 border rounded text-sm focus:outline-none focus:ring focus:border-blue-500' name="instructor" id="instructor" placeholder='Enter Instructor Name'/>
        </div>
        <div className="flex-1 flex flex-col mb-4 mr-4">
          <label htmlFor="rating" className="mb-2 text-sm">Rating</label>
          <input type="text" className='w-full p-2 border rounded text-sm focus:outline-none focus:ring focus:border-blue-500' name="rating" id="rating" placeholder='Enter Rating 1-10'/>
        </div>
        <div className="flex-1 flex flex-col">
          <label htmlFor="submit" className="mb-2 text-sm invisible font-bold">Submit</label>
          <input type="submit" className='w-full p-2 border rounded text-sm bg-red-900 text-white cursor-pointer focus:outline-none focus:ring focus:border-blue-900' value='Submit'/>
        </div>
      </div>
    </div>






      <div className="flex gap-10"> 
        <div className="flex-grow-2 bg-gray-100 w-full rounded shadow p-2">
          <div className="mb-5 bg-white px-2 rounded border">
            <p className="text-xl font-bold">Course Rating</p>
          </div>
          <div>
            {courseRating.map((_, index) => (
              <div className='mb-4' key={index}>
                <div
                  className="flex justify-between w-full p-2"
                  
                >
                  <div className="w-full">
                    <p className="">Math 027: Linear Algebra</p>
                    <p className="text-sm text-gray-500 ">
                      Vasanta Chaganti | Natural Science
                    </p>
                    <span className="text-xs px-2 py-1 bg-[#bf3134] text-white rounded">
                      Swarthmore College
                    </span>
                  </div>
                  <div className="inline-flex items-center">
                  <AiTwotoneStar className="mr-1" />
                  <p>9/10</p>
                </div>
              </div>

                <hr className="text-gray-300 mt-2" />
              </div>
            ))}
          </div>
        </div>
        <div className="flex-grow-1 w-full border-gray-200 p-2">
          <div className="flex justify-between">
            <p className="text-xl font-bold">
              Recent Research Opportunities
            </p>
            <span className="text-sm my-auto">More..</span>
          </div>
          <hr className="text-gray-300 my-4" />
          {researchOpportunities.map((_, index) => (
            <div
              key={index}
              className="mb-4 p-2 bg-gray-100 rounded border border-gray-400"
            >
              <p>Summer Computer Science Research</p>
              <div>
                <p className="text-sm text-gray-500 mb-2">
                  Vasanta Chaganti | Natural Science
                </p>
                <span className="text-xs px-2 py-1 bg-[#bf3134] text-white rounded ">
                  Swarthmore College
                </span>
              </div>
            </div>
          ))}
        </div>
      </div>

      <div className="">
        <div className="mb-4 mt-8">
          <h2 className="text-xl font-bold ">Trico Events</h2>
          <span className="text-sm text-gray-600">per week</span>
        </div>
        <ul className="grid gap-4 grid-cols-1 md:grid-cols-2 lg:grid-cols-5">
          {events.map((event) => (
            <li
              key={event.id}
              className="bg-gray-100 p-4 border rounded border-gray-400"
            >
              <h3 className="font-semibold">{event.title}</h3>
              <p className="text-sm text-gray-600 underline">
                Date: {event.date}
              </p>
              <p className="text-sm text-gray-600 ">Host: {event.host}</p>
              <p className="text-sm text-gray-600">
                Location: {event.location}
              </p>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}
