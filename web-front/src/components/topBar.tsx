import { Button } from "@/components/ui/button";
import { Link } from "react-router-dom";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "./ui/dropdown-menu";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Switch } from "./ui/switch";

export default function TopBar() {
  return (
    <div className="flex w-full flex-col">
      <header className="sticky top-0 flex h-16 items-center gap-4 border-b bg-background px-4 md:px-6">
        <div className="flex justify-between w-full items-center">
          
          {/* Left Section: Mountain Icon */}
          <div className="flex items-center">
            <Link className="flex items-center" to={"/"}>
              <MountainIcon className="h-6 w-6" />
              <span className="sr-only">Home</span>
            </Link>
          </div>

          {/* Center Section: Navigation Links */}
          <nav className="hidden md:flex gap-4">
            <Link
              className="font-medium text-sm transition-colors hover:underline"
              to={"/"}
            >
              Home
            </Link>
            <Link
              className="font-medium text-sm transition-colors hover:underline"
              to={"/about"}
            >
              About
            </Link>
            <Link
              className="font-medium text-sm transition-colors hover:underline"
              to={"/contact"}
            >
              Contact
            </Link>
          </nav>

          {/* Right Section: Sign In/Up or User Icon */}
          <div className="flex items-center">
            {/* <Button size="sm" variant="outline">Sign in</Button>
          <Button size="sm">Sign up</Button> */}
            <Switch className="mr-5" />
            <DropdownMenu>
              <DropdownMenuTrigger asChild>
                <Button
                  variant="secondary"
                  size="icon"
                  className="rounded-full"
                >
                  <Avatar>
                    <AvatarImage
                      src="https://github.com/shadcn.pngs"
                      alt="@shadcn"
                    />
                    <AvatarFallback>Me</AvatarFallback>
                  </Avatar>
                </Button>
              </DropdownMenuTrigger>
              <DropdownMenuContent align="end">
                <DropdownMenuLabel>My Account</DropdownMenuLabel>
                <DropdownMenuSeparator />
                <DropdownMenuItem>Settings</DropdownMenuItem>
                <DropdownMenuItem>Support</DropdownMenuItem>
                <DropdownMenuSeparator />
                <DropdownMenuItem>Logout</DropdownMenuItem>
              </DropdownMenuContent>
            </DropdownMenu>
          </div>
        </div>
      </header>
    </div>
  );
}

function MountainIcon(props: any) {
  return (
    <svg
      {...props}
      xmlns="http://www.w3.org/2000/svg"
      width="24"
      height="24"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      strokeWidth="2"
      strokeLinecap="round"
      strokeLinejoin="round"
    >
      <path d="m8 3 4 8 5-5 5 15H2L8 3z" />
    </svg>
  );
}
