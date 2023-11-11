// components/FilterBar.js

import Select from 'react-select';

const SemesterOptions = [
  { value: 'Fall 2023', label: 'Fall 2023' },
  { value: 'Spring 2024', label: 'Spring 2024' },
];

const CollegeOptions = [
    { value: 'swarthmore', label: 'Swarthmore' },
    { value: 'bryn mawr', label: 'Bryn Mawr' },
    { value: 'haverfod', label: 'Haverfod' },
];

const DistributionOptions = [
    { value: 'artsandhhumanities', label: 'Arts and Humanities' },
    { value: 'naturalscience', label: 'Natural Science and Engineering' },
    { value: 'socialscience', label: 'Social Science' },

];


const optionsArray = [
  { label: 'College', options: CollegeOptions },
  { label: 'Semester', options: SemesterOptions },
  { label: 'Distribution', options: DistributionOptions },
];

const FilterBarResearch = () => {
  return (
    <div className='inline-flex gap-4 bg-gray-200 py-2 px-4 rounded mr-20'>
      {optionsArray.map(({ label, options }, i) => (
        <Select
          key={i}
          className="filter-dropdown text-sm"
          options={options}
          placeholder={label}
        />
      ))}
      <button className='bg-blue-500 px-3 text-white rounded text-sm'>Apply</button>
    </div>
  );
};

export default FilterBarResearch;
