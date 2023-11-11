import { FaSearch } from "react-icons/fa";

// components/Search.js

interface SearchType {
  placeholder: string;
}

export default function Search(props: SearchType) {
  return (
    <form className="flex-grow my-auto">
      <label htmlFor="default-search" className="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white">
        Search
      </label>
      <div className="relative">
        <div className="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
          <FaSearch />
        </div>
        <input
          type="search"
          id="default-search"
          className="w-full text-sm py-3 px-6 ps-10  text-gray-900 border bg-white border-gray-300 rounded focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          placeholder={props.placeholder}
          required
        />
      </div>
    </form>
  );
}
