"use client"


import NavBar from "../component/navbar";
import FilterBar from "../component/filter";


export default function Course() {
  return (
    <div className='bg-gray-50'>

        {/* Header */}
        <NavBar/>
        
        {/* Body */}
        <div className="px-28 mt-5">
          <div>
            <FilterBar/>
          </div>
          
        </div>
    </div>
  )
}
