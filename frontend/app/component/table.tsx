interface CourseData {
    title: string;
    college: string;
    category: string;
    instructor: string;
    schedule: string;
    rating: string;
    room: string;
    max_enrollment: number;
  }
  
  interface ResearchData {
    title: string;
    college: string;
    category: string;
    instructor: string;
    schedule: string;
    openings: number;
  }
  
  type TableData = CourseData[] | ResearchData[];
  
  interface TableProp {
    data: TableData;
  }
  
  export default function Table({ data }: TableProp) {
    return (
      <table className="table-auto w-full rounded">
        {/* ... your table header */}
        <thead className="text-left">
          <tr className="bg-[#bf3134] text-white rounded">
            <th className="ml-2 py-2 px-4 rounded-tl">Course</th>
            <th className="py-2 px-4">College</th>
            <th className="py-2 px-4">Distribution</th>
            <th className="py-2 px-4">Instructor</th>
            <th className="py-2 px-4">Time</th>
            {Array.isArray(data) && 'rating' in data[0] && (
              <th className="py-2 px-4">Rating</th>
            )}
            {Array.isArray(data) && 'room' in data[0] && (
              <th className="py-2 px-4">Room</th>
            )}
            {Array.isArray(data) && 'openings' in data[0] && (
              <th className="py-2 px-4">Openings</th>
            )}
             {Array.isArray(data) && 'max_enrollment' in data[0] && (
              <th className="py-2 px-4">Max Enrollment</th>
            )}

          </tr>
        </thead>
        <tbody>
          {data.map((item, index) => (
            <tr key={index} className={`py-3 ${index % 2 === 0 ? 'bg-gray-100' : ''}`}>
              <td className="py-4 px-4 rounded-bl">{item.title}</td>
              <td className="py-4 px-4">{item.college}</td>
              <td className="py-4 px-4">{item.category}</td>
              <td className="py-4 px-4">{item.instructor}</td>
              <td className="py-4 px-4">{item.schedule}</td>
              {Array.isArray(data) && 'rating' in item && (
                <td className="py-4 px-4">{item.rating}</td>
              )}
              {Array.isArray(data) && 'room' in item && (
                <td className="py-4 px-4">{item.room}</td>   
              )}
              {Array.isArray(data) && 'openings' in item && (
                <td className="py-4 px-4">{item.openings}</td>   
              )}
            {Array.isArray(data) && 'max_enrollment' in item && (
                <td className="py-4 px-4">{item.max_enrollment}</td>   
              )}

            </tr>
          ))}
        </tbody>
      </table>
    );
  }
  