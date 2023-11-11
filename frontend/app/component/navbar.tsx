import { Open_Sans } from 'next/font/google'
import Link from 'next/link';
import { BiSolidBookContent } from 'react-icons/bi';
import { FaMicroscope } from 'react-icons/fa';
import Image from 'next/image';

const inter = Open_Sans({ subsets: ['latin'] })


export default function NavBar() {
    return (
        <div className="bg-white flex justify-between items-center px-28 py-3 shadow-sm">
        <div>
            <Image src="/logo.svg" alt={''} width={150} height={150} />
        </div>
        
        <div className="text-white flex items-center text-sm">
            <button className='py-1.5 px-2 bg-[#bf3135] rounded inline-flex gap-2 mr-4 hover:bg-red-400'>
                <BiSolidBookContent className="text-lg my-auto"/>
                <Link href={"/course"}>Course</Link>
            </button>
            <button className='py-1.5 px-2 bg-[#bf3135] rounded inline-flex gap-2 mr-4 hover:bg-red-400'>
                <FaMicroscope className="text-lg my-auto"/>
                <Link href={"/research"}>Research</Link>
            </button>    
            <button className='py-1.5 px-6 bg-[#bf3135] rounded inline-flex gap-2 hover:bg-red-400'>
                <span className=''>Login</span>
            </button>
        </div>
    </div>
    
    )
}