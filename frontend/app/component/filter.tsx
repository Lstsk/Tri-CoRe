"use client"

// components/FilterBar.js

import Select from 'react-select';

const options = [
  { value: 'filter1', label: 'Filter 1' },
  { value: 'filter2', label: 'Filter 2' },
  { value: 'filter3', label: 'Filter 3' },
];

const filter_options = [
    "College", "Semester", "Distribution", "Rating"
]

const FilterBar = () => {



  return (
    <div className='inline-flex gap-2 bg-gray-200 py-2 px-4 rounded'>
        <div className="">

        
        <div className="">
        <Select
            className="filter-dropdown text-sm"
            options={options}
            placeholder="Distribution"
        />
        </div>
    </div>
    </div>
  );
};

export default FilterBar;
