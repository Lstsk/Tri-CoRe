import { Divide } from 'lucide-react';
import Image from 'next/image';

export default function Home() {

  const researchOpportunities = Array.from({ length: 10 });

  return (
    <div className='px-28 w-full mt-10'>
      <div className='flex gap-2'>
        <div className='flex-grow-2 bg-gray-400 w-full'>
          hello
          {/* Content for the first div */}
        </div>
        <div className='flex-grow-1 bg-gray-100 w-full border border-gray-200 p-2'>
          <p className='text-md'>Recent Research Opportunities</p>
          <hr className='text-gray-300'/>
          {researchOpportunities.map((_, index) => (
              // Render something for each iteration
              <div key={index} className='mb-2'>
                <p>Summer Computer Science Research</p>
                <div>
                  <p className='text-sm text-gray-500'>Vasanta Chaganti</p>
                  <span className='text-sm'>Natural Science</span>
                  <span className='text-sm px-2 py-1 bg-[#bf3134] text-white rounded'>Swarthmore College</span>
                </div>
              </div>
            ))}
        </div>
      </div>
    </div>
  );
}
