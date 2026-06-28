import Link from "next/link";
import { getCurrentUser } from "@/lib/auth";
import LogoutButton from "@/components/logout-button";

export default async function Navbar(){
    const user = await  getCurrentUser();

    return (
        <header className="border-b border-gray-200 bg-white">
            <nav className="mx-auto max-w-6x1 items-center justify-between px-6 py-4">
                <Link href="/products" className="text-lg font-bold text-gray-900">
                My Store
                </Link>

                <div className="flex items-center gap-4 text-sm">
                    {user ? (
                        <>
                        <Link href="/account" className="text-gray-600 hover:text-gray-900">
                            {user.email}
                        </Link>
                        <LogoutButton/>
                        </>
                    ) : (
                        <>
                        <Link href="/login" className="text-gray-600 hover:text-gray-900">
                           Sign in
                        </Link>
                        <Link
                          href="/register"
                          className="rounded-lg bg-gray-900 px-4 py-2 font-medium text-white hover:bg-gray-800"
                        >
                          Create Account
                        </Link>
                        </>
                    )}
                </div>
                </nav>
                </header>
    );
}