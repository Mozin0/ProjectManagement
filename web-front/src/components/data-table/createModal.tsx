import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
  } from "@/components/ui/dialog";
  import { Button } from "@/components/ui/button";
  import { Input } from "@/components/ui/input";
  import { Label } from "@/components/ui/label";
  import { Calendar } from "@/components/ui/calendar";
  import {
    Popover,
    PopoverContent,
    PopoverTrigger,
  } from "@/components/ui/popover";
  import { CalendarIcon } from "lucide-react";
  import { cn } from "@/lib/utils";
  import { format } from "date-fns";

interface ModalProps {
    name: string,
    openDialog: boolean,
    setOpenDialog: (open: boolean) => void,
    objectName: string,
    setObjectName: (objectName: string) => void,
    create: () => void,
    date: Date | undefined,
    setDate: (date: Date | undefined) => void,
}

const CreateModal = ( {name, openDialog, setOpenDialog, objectName, setObjectName, create, date, setDate} : ModalProps) => {
    return (
              <Dialog open={openDialog} onOpenChange={setOpenDialog}>
                <DialogTrigger asChild>
                  <Button variant="secondary" className="w-auto mr-4 rounded-[12px]">
                    Create New {name}
                  </Button>
                </DialogTrigger>
                <DialogContent className="sm:max-w-[425px]">
                  <DialogHeader>
                    <DialogTitle>Create a New {name}</DialogTitle>
                    <DialogDescription>
                      Add a new {name}. Click create when you're done.
                    </DialogDescription>
                  </DialogHeader>
                  <div className="grid gap-4 py-4">
                    <div className="grid grid-cols-4 items-center gap-4">
                      <Label htmlFor="name" className="text-right">
                        Name
                      </Label>
                      <Input
                        id="name"
                        placeholder={`${name} Name...`}
                        value={objectName}
                        onChange={(e) => setObjectName(e.target.value)}
                        className="col-span-3"
                      />
                    </div>
                    <div className="grid grid-cols-4 items-center gap-4">
                      <Label htmlFor="username" className="text-right">
                        Deadline
                      </Label>
                      <Popover>
                        <PopoverTrigger asChild>
                          <Button
                            variant={"outline"}
                            className={cn(
                              "w-[280px] justify-start text-left font-normal",
                              !date && "text-muted-foreground"
                            )}
                          >
                            <CalendarIcon className="mr-2 h-4 w-4" />
                            {date ? format(date, "PPP") : <span>Pick a date</span>}
                          </Button>
                        </PopoverTrigger>
                        <PopoverContent className="w-auto p-0">
                          <Calendar
                            mode="single"
                            selected={date}
                            onSelect={(selectedDate) => setDate(selectedDate)}
                            initialFocus
                            fromDate={new Date()}
                          />
                        </PopoverContent>
                      </Popover>
                    </div>
                  </div>
                  <DialogFooter>
                    <Button type="submit" onClick={create}>
                      Create {name}
                    </Button>
                  </DialogFooter>
                </DialogContent>
              </Dialog>
            );
};

export default CreateModal;